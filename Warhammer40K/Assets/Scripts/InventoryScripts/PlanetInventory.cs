using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlanetInventory : Planet
{
    ///Local ship Inventory of planets

    private void Awake()
    {
        max_fleet_count = 10;
        pfm = GameObject.FindGameObjectWithTag("planet_fleet_menu").GetComponentInChildren<PlanetFleetMenu>();
    }

    public Fleet[] GetFleets()
    {
        return fleet;
    }

    public Card[] GetCardsFromFleet(int index)
    {
        return fleet[index].GetCards();
    }

    public string GetName()
    {
        return planet_name;
    }

    public int GetMaxFleetCount()
    {
        return max_fleet_count;
    }
}
