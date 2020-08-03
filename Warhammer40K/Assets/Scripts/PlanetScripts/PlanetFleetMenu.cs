using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlanetFleetMenu : MonoBehaviour
{
    private int max_cards = 150;

    private List<GameObject> card_collection = new List<GameObject>();

    private static Vector3 position_correction;

    [SerializeField] private PlanetInventory curr_planet;
    private TextMeshProUGUI curr_planet_name;

    //text colors
    private Color fleet_count_text_color;
    private Color reset_color;

    protected TextMeshProUGUI planet_fleet_count_text;

    private Fleet[] fleets;

    private enum STATE
    {
        ACTIVE,
        NOT_ACTIVE,
        NONE
    }

    private STATE CURR_STATE;

    private void Awake()
    {
        ContentSizeFitter all_ship_cards = GameObject.FindGameObjectWithTag("pfm_cards_container").GetComponent<ContentSizeFitter>();
        
        for (int i = 0; i < max_cards; i++)
        {
            card_collection.Add(all_ship_cards.transform.GetChild(i).gameObject);
        }
        curr_planet_name = gameObject.transform.GetChild(0).transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        planet_fleet_count_text = GameObject.FindGameObjectWithTag("fleet_count_text").GetComponent<TextMeshProUGUI>();
        position_correction = new Vector3(3, 0, 0);
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
        gameObject.SetActive(true);
        CURR_STATE = STATE.ACTIVE;
        curr_planet = inv;

        fleets = curr_planet.GetFleets();
        curr_planet_name.text = curr_planet.GetName();

        SetText();

        //TODO:
        //set the cards to enable their renderer

    }

    public void Refresh()
    {
        fleets = curr_planet.GetFleets();
        curr_planet_name.text = curr_planet.GetName();

        SetText();
    }

    private void SetText()
    {
        if (curr_planet.GetFleets().Length < curr_planet.GetMaxFleetCount())
        {
            //planet_fleet_count_text.color = reset_color;
        }
        else
        {
            //planet_fleet_count_text.color = fleet_count_text_color;
        }
        
        planet_fleet_count_text.text = "Ship Capacity: " + curr_planet.GetFleets().Length + "/" + curr_planet.GetMaxFleetCount();
    }

    public void Clear()
    {
        gameObject.SetActive(false);
        CURR_STATE = STATE.NONE;
        curr_planet = null;
        
    }
}
