using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlanetInventory : Planet
{
    ///Local ship Inventory of planets

    private void Awake()
    {
        fleets.Add((Fleet) ScriptableObject.CreateInstance(typeof(Fleet)));
        fleets.Add((Fleet) ScriptableObject.CreateInstance(typeof(Fleet)));

        max_fleet_count = 10;
        pfm = GameObject.FindGameObjectWithTag("planet_fleet_menu").GetComponentInChildren<PlanetFleetMenu>();

        Ship ship = (Ship)ScriptableObject.CreateInstance(typeof(Ship));
        ship.ShipSetup("HMS Indomitable", ShipEnums.FACTION.IMPERIUM, ShipEnums.SHIP_CLASS.BATTLESHIP, 10000);
        Ship ship1 = (Ship)ScriptableObject.CreateInstance(typeof(Ship));
        ship1.ShipSetup("HMS Indomitable", ShipEnums.FACTION.IMPERIUM, ShipEnums.SHIP_CLASS.BATTLESHIP, 10000);

        Ship ship2 = (Ship)ScriptableObject.CreateInstance(typeof(Ship));
        ship2.ShipSetup("HMS Retard", ShipEnums.FACTION.IMPERIUM, ShipEnums.SHIP_CLASS.CRUISER, 2000);

        fleets[0].AddShipToFleet(ship);
        fleets[0].AddShipToFleet(ship1);
        fleets[1].AddShipToFleet(ship2);
    }

    public List<Fleet> GetFleets()
    {
        return fleets;
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
