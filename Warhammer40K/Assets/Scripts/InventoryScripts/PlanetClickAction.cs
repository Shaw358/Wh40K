using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetClickAction : MonoBehaviour
{
    private PlanetFleetMenu pfm;
    Planet planet;

    private void Awake()
    {
        planet = gameObject.GetComponent<Planet>();
        pfm = GameObject.Find("planet_menu_container").GetComponent<PlanetFleetMenu>();
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (planet.GetFaction() == Factions.FACTION.PLAYER)
            {
                pfm.Activate(planet);
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (planet.GetFaction() == Factions.FACTION.PLAYER)
            {
                pfm.MoveFleetOnMap(planet);
            }
        }
    }
}
