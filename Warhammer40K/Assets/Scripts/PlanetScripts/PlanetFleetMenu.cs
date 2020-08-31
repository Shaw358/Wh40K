using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class PlanetFleetMenu : MonoBehaviour
{
    FleetSelector fleet_selector;
    InventoryUiMovement ui_move;

    private int max_cards = 20;

    private static Vector3 position_correction;

    [SerializeField] private PlanetInventory curr_planet;
    private TextMeshProUGUI curr_planet_name;

    //text colors
    private Color fleet_count_text_color;
    private Color reset_color;

    protected TextMeshProUGUI planet_fleet_count_text;

    private List<Fleet> fleets = new List<Fleet>();
    private List<int> fleets_selected = new List<int>();
    private List<GameObject> fleet_cards = new List<GameObject>();

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
        ContentSizeFitter all_ship_cards;
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

        /*for (int i = 0; i < fleets.Count; i++)
        {
            fleets[i] = null;
        }*/
    }

    public void CardTransferFleetSelector(SELECTION_TYPE FLEET_SELECTION_TYPE, int s_index /*sibling index*/)
    {
        ui_move.Enable(true);
        List<Fleet> local_fleets = new List<Fleet>();

        switch (FLEET_SELECTION_TYPE)
        {
            case SELECTION_TYPE.SINGLE:
                ClearFleetsSelected(SELECTION_TYPE.SINGLE);

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
                if (fleets_selected.Count > 0)
                {
                    int fleet_to_add = 0;
                    ClearFleetsSelected(SELECTION_TYPE.SHIFT);
                    if (fleets_selected[0] > s_index)
                    {
                        for (int i = fleets_selected[0]; i > s_index; i--)
                        {
                            fleets_selected.Add(s_index + fleet_to_add);
                            fleet_to_add++;
                        }
                    }
                    else
                    {
                        for (int i = fleets_selected[0]; i < s_index; i++)
                        {
                            print(s_index + fleet_to_add);
                            fleet_to_add++;
                            fleets_selected.Add(fleets_selected[0] + fleet_to_add);
                        }
                    }

                    /*Debug.Log(fleets_selected.Count);
                    foreach(int i in fleets_selected)
                    {
                        print(i);
                    }*/
                    Debug.Log(fleets.Count + " " + fleets_selected.Count);
                    for (int j = 0; j < fleets_selected.Count; j++)
                    {
                        //print(fleets_selected[j]);
                        local_fleets.Add(fleets[fleets_selected[j]]);
                    }
                }
                else
                {
                    fleets_selected.Add(s_index);
                    local_fleets.Add(fleets[s_index]);
                }
                break;
        }
        fleet_selector.SetFleets(local_fleets);
    }

    public void ClearFleetsSelected(SELECTION_TYPE TYPE)
    {
        switch(TYPE)
        {
            case SELECTION_TYPE.SINGLE:
                fleets_selected.Clear();
                break;
            case SELECTION_TYPE.SHIFT:
                if(fleets_selected.Count > 1)
                {
                    int first_remove = 1;
                    fleets_selected.RemoveRange(first_remove, fleets_selected.Count - 1);
                }
                break;
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
}