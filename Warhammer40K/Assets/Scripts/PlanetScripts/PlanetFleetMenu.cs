using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class PlanetFleetMenu : MonoBehaviour
{
    private GameObject card_collection;

    private static Vector3 position_correction;

    [SerializeField] private PlanetInventory curr_planet;
    private Fleet[] fleets;

    private bool planet_tracking;

    private enum STATE
    {
        ACTIVE,
        NOT_ACTIVE,
        NONE
    }

    private STATE CURR_STATE;

    private void Awake()
    {

    }

    private void Start()
    {
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

    public void SetPlanet(PlanetInventory inv)
    {
        curr_planet = inv;

        fleets = curr_planet.GetFleets();

    }

    public void Clear()
    {
        CURR_STATE = STATE.NONE;
        curr_planet = null;
    }
}
