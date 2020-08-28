using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Ground : MonoBehaviour
{
    private PlanetFleetMenu planet_fleet_menu;

    private void Awake()
    {
        planet_fleet_menu = FindObjectOfType<Canvas>().GetComponentInChildren<PlanetFleetMenu>();
    }
    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        else
        {
            if(planet_fleet_menu.GetState() == PlanetFleetMenu.STATE.ACTIVE)
            {
                planet_fleet_menu.Clear();
            }
            planet_fleet_menu.ClearFleetsSelected(PlanetFleetMenu.SELECTION_TYPE.SINGLE);
        }
    }
}
