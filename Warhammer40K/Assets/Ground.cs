using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private PlanetFleetMenu planet_fleet_menu;

    private void Awake()
    {
        planet_fleet_menu = FindObjectOfType<Canvas>().GetComponentInChildren<PlanetFleetMenu>();
    }

    private void OnMouseDown()
    {
        planet_fleet_menu.Clear();
    }
}
