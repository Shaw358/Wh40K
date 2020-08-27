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
        fleets.Add((Fleet)ScriptableObject.CreateInstance(typeof(Fleet)));
        fleets.Add((Fleet)ScriptableObject.CreateInstance(typeof(Fleet)));

        max_fleet_count = 10;
        pfm = GameObject.FindGameObjectWithTag("planet_fleet_menu").GetComponentInChildren<PlanetFleetMenu>();

        Ship ship = (Ship)ScriptableObject.CreateInstance(typeof(Ship));
        ship.ShipSetup("HMS Indomitable", ShipEnums.FACTION.IMPERIUM, ShipEnums.SHIP_CLASS.BATTLESHIP, 10000);
        Ship ship1 = (Ship)ScriptableObject.CreateInstance(typeof(Ship));
        ship1.ShipSetup("HMS Indomitable", ShipEnums.FACTION.IMPERIUM, ShipEnums.SHIP_CLASS.BATTLESHIP, 10000);

        Ship ship2 = (Ship)ScriptableObject.CreateInstance(typeof(Ship));
        ship2.ShipSetup("HMS Retard", ShipEnums.FACTION.IMPERIUM, ShipEnums.SHIP_CLASS.CRUISER, 2000);

        Ship ship3 = (Ship)ScriptableObject.CreateInstance(typeof(Ship));
        ship3.ShipSetup("HMS Cruiser", ShipEnums.FACTION.IMPERIUM, ShipEnums.SHIP_CLASS.LIGHT_CRUISER, 10000);
        Ship ship4 = (Ship)ScriptableObject.CreateInstance(typeof(Ship));
        ship4.ShipSetup("HMS Shit", ShipEnums.FACTION.IMPERIUM, ShipEnums.SHIP_CLASS.FRIGATE, 10000);

        Ship ship5 = (Ship)ScriptableObject.CreateInstance(typeof(Ship));
        ship5.ShipSetup("HMS Blyaat", ShipEnums.FACTION.IMPERIUM, ShipEnums.SHIP_CLASS.DESTROYER, 2000);

        Ship ship6 = (Ship)ScriptableObject.CreateInstance(typeof(Ship));
        ship6.ShipSetup("HMS DEUTSCHLAND", ShipEnums.FACTION.IMPERIUM, ShipEnums.SHIP_CLASS.SPECIAL, 10000);
        Ship ship7 = (Ship)ScriptableObject.CreateInstance(typeof(Ship));
        ship7.ShipSetup("HMS MOveit", ShipEnums.FACTION.IMPERIUM, ShipEnums.SHIP_CLASS.BATTLE_CRUISER, 10000);

        Ship ship8 = (Ship)ScriptableObject.CreateInstance(typeof(Ship));
        ship8.ShipSetup("HMS Michael Jackson", ShipEnums.FACTION.IMPERIUM, ShipEnums.SHIP_CLASS.CRUISER, 2000);
        Ship ship9 = (Ship)ScriptableObject.CreateInstance(typeof(Ship));
        ship9.ShipSetup("HMS Special Retard", ShipEnums.FACTION.IMPERIUM, ShipEnums.SHIP_CLASS.CRUISER, 2000);

        fleets[0].AddShipToFleet(ship);
        fleets[1].AddShipToFleet(ship1);
        fleets[1].AddShipToFleet(ship2);
        fleets[2].AddShipToFleet(ship3);
        fleets[2].AddShipToFleet(ship4);
        fleets[2].AddShipToFleet(ship5);
        fleets[3].AddShipToFleet(ship6);
        fleets[3].AddShipToFleet(ship7);
        fleets[3].AddShipToFleet(ship8);
        fleets[3].AddShipToFleet(ship9);
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
