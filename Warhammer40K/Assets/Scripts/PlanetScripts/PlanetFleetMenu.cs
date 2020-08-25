using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class PlanetFleetMenu : MonoBehaviour
{
    FleetSelector fleet_selector;
    InventoryUiMovement ui_move;

    [SerializeField] private ContentSizeFitter all_ship_cards;

    private int max_cards = 20;

    private static Vector3 position_correction;

    [SerializeField] private PlanetInventory curr_planet;
    private TextMeshProUGUI curr_planet_name;

    //text colors
    private Color fleet_count_text_color;
    private Color reset_color;

    protected TextMeshProUGUI planet_fleet_count_text;

    private List<Fleet> fleets = new List<Fleet>();

    private List<GameObject> fleet_cards = new List<GameObject>();

    private List<int> fleets_selected = new List<int>();

    public enum STATE
    {
        ACTIVE,
        NOT_ACTIVE,
        NONE
    }

    private STATE CURR_STATE;
    public enum SELECTION_TYPE
    {
        SINGLE,
        CONTROL,
        SHIFT,
        NONE
    }

    private void Awake()
    {
        ui_move = GameObject.Find("right_menu_container").GetComponent<InventoryUiMovement>();
        fleet_selector = new FleetSelector();
        fleet_selector.Setup();

        CURR_STATE = STATE.NOT_ACTIVE;
        all_ship_cards = GameObject.FindGameObjectWithTag("pfm_cards_container").GetComponent<ContentSizeFitter>();

        for (int i = 0; i < max_cards; i++)
        {
            fleet_cards.Add(all_ship_cards.transform.GetChild(i).transform.gameObject);
        }

        curr_planet_name = gameObject.transform.GetChild(0).transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        planet_fleet_count_text = GameObject.FindGameObjectWithTag("fleet_count_text").GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        position_correction = new Vector3(4, 0, 0);

        for (int i = 0; i < fleet_cards.Count; i++)
        {
            fleet_cards[i].gameObject.SetActive(false);
        }
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (CURR_STATE == STATE.ACTIVE)
        {
            TrackPlanet();
        }
    }

    private void TrackPlanet()
    {
        transform.position = Camera.main.WorldToScreenPoint(curr_planet.transform.position + position_correction);
    }

    public void Activate(PlanetInventory inv)
    {
        ui_move.Enable(true);
        CURR_STATE = STATE.ACTIVE;
        gameObject.SetActive(true);
        curr_planet = inv;

        fleets = curr_planet.GetFleets();
        curr_planet_name.text = curr_planet.GetName();

        int fleet_amount = curr_planet.GetFleets().Count;

        Ship[] testShips = fleets[0].GetShips();

        //SortCardHierarchy(fleet_amount);
        for (int i = 0; i < fleet_amount; i++)
        {
            fleet_cards[i].SetActive(true);
        }

        SetText();
    }

    public void Refresh()
    {
        fleets = curr_planet.GetFleets();
        curr_planet_name.text = curr_planet.GetName();

        SetText();
    }

    private void SortCardHierarchy(int fleet_amount)
    {
        for (int i = 0; i < fleet_amount; i++)
        {
            Debug.Log(fleet_cards[i]);
            fleet_cards[i].gameObject.transform.SetSiblingIndex(i);
        }
    }

    private void SetText()
    {
        if (curr_planet.GetFleets().Count < curr_planet.GetMaxFleetCount())
        {
            //planet_fleet_count_text.color = reset_color;
        }
        else
        {
            //planet_fleet_count_text.color = fleet_count_text_color;
        }

        planet_fleet_count_text.text = "Ship Capacity: " + curr_planet.GetFleets().Count + "/" + curr_planet.GetMaxFleetCount();

        //TODO:
        //supply text
    }

    public void Clear()
    {
        gameObject.SetActive(false);
        CURR_STATE = STATE.NONE;
        curr_planet = null;

        for (int i = 0; i < fleets.Count; i++)
        {
            fleets[i] = null;
        }
    }

    public STATE GetState()
    {
        return CURR_STATE;
    }

    public List<Fleet> GetFleets()
    {
        return fleets;
    }    

    public void CardTransferFleetSelector(SELECTION_TYPE TEMP_SELECTION_TYPE, int s_index /*sibling index*/)
    {
        ui_move.Enable(true);
        List<Fleet> local_fleets = new List<Fleet>();

        switch (TEMP_SELECTION_TYPE)
        {
            case SELECTION_TYPE.SINGLE:
                ClearFleetsSelected();

                fleets_selected.Add(s_index);

                local_fleets.Add(fleets[s_index]);
                break;

            case SELECTION_TYPE.CONTROL:
                print("Here");
                if (fleets_selected.Contains(s_index))
                {
                    fleets_selected.Remove(s_index);
                }
                else
                {
                    fleets_selected.Add(s_index);
                }

                for (int i = 0; i < fleets_selected.Count; i++)
                {
                    local_fleets.Add(fleets[fleets_selected[i]]);
                }
                break;

            case SELECTION_TYPE.SHIFT:
                //fleets_selected[0] - fleets_selected[s_index]
                if(fleets_selected.Count > 0 )
                {
                    for(int j = 0; j < s_index; j++)
                    {
                        fleets_selected[j + 1] = s_index + j;
                    }
                }
                else
                {
                    fleets_selected[0] = s_index;
                    local_fleets[0] = fleets[s_index];
                }

                for (int i = 0; i < fleets_selected.Count; i++)
                {
                    local_fleets.Add(fleets[fleets_selected[i]]);
                }

                break;
        }

        //add stuff to localfleet here
        fleet_selector.SetCards(local_fleets.ToArray());
    }

    public void ClearFleetsSelected()
    {
        fleets_selected.Clear();
    }
}