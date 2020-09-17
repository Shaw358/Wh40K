﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    /// <summary>
    /// Overall class to keep track of basic stats that belong on every planet
    /// </summary>
    protected int max_supply;
    private Inventory<Fleet> fleets = new Inventory<Fleet>();

    [SerializeField] protected string planet_name;
    private TravelLanes travel_lanes;

    //protected List<Fleet> fleets = new List<Fleet>(); //fleets present in system

    private void Awake()
    {
        max_supply = 10;
        travel_lanes = GetComponentInChildren<TravelLanes>();

        #region deubbing
        fleets.AddItem((Fleet)ScriptableObject.CreateInstance(typeof(Fleet)));
        fleets.AddItem((Fleet)ScriptableObject.CreateInstance(typeof(Fleet)));
        fleets.AddItem((Fleet)ScriptableObject.CreateInstance(typeof(Fleet)));
        fleets.AddItem((Fleet)ScriptableObject.CreateInstance(typeof(Fleet)));

        Ship ship = (Ship)ScriptableObject.CreateInstance(typeof(Ship));
        ship.ShipSetup("HMS Indomitable", ShipEnums.FACTION.IMPERIUM, ShipEnums.SHIP_CLASS.BATTLESHIP, 1000);
        Ship ship1 = (Ship)ScriptableObject.CreateInstance(typeof(Ship));
        ship1.ShipSetup("HMS henk", ShipEnums.FACTION.IMPERIUM, ShipEnums.SHIP_CLASS.BATTLESHIP, 2000);

        Ship ship2 = (Ship)ScriptableObject.CreateInstance(typeof(Ship));
        ship2.ShipSetup("HMS Retard", ShipEnums.FACTION.IMPERIUM, ShipEnums.SHIP_CLASS.CRUISER, 3000);

        Ship ship3 = (Ship)ScriptableObject.CreateInstance(typeof(Ship));
        ship3.ShipSetup("HMS Cruiser", ShipEnums.FACTION.IMPERIUM, ShipEnums.SHIP_CLASS.LIGHT_CRUISER, 4000);
        Ship ship4 = (Ship)ScriptableObject.CreateInstance(typeof(Ship));
        ship4.ShipSetup("HMS Shit", ShipEnums.FACTION.IMPERIUM, ShipEnums.SHIP_CLASS.FRIGATE, 5000);

        Ship ship5 = (Ship)ScriptableObject.CreateInstance(typeof(Ship));
        ship5.ShipSetup("HMS Blyaat", ShipEnums.FACTION.IMPERIUM, ShipEnums.SHIP_CLASS.DESTROYER, 6000);

        Ship ship6 = (Ship)ScriptableObject.CreateInstance(typeof(Ship));
        ship6.ShipSetup("HMS DEUTSCHLAND", ShipEnums.FACTION.IMPERIUM, ShipEnums.SHIP_CLASS.SPECIAL, 7000);
        Ship ship7 = (Ship)ScriptableObject.CreateInstance(typeof(Ship));
        ship7.ShipSetup("HMS MOveit", ShipEnums.FACTION.IMPERIUM, ShipEnums.SHIP_CLASS.BATTLE_CRUISER, 8000);

        Ship ship8 = (Ship)ScriptableObject.CreateInstance(typeof(Ship));
        ship8.ShipSetup("HMS Michael Jackson", ShipEnums.FACTION.IMPERIUM, ShipEnums.SHIP_CLASS.CRUISER, 9000);
        Ship ship9 = (Ship)ScriptableObject.CreateInstance(typeof(Ship));
        ship9.ShipSetup("HMS Special Retard", ShipEnums.FACTION.IMPERIUM, ShipEnums.SHIP_CLASS.CRUISER, 10000);

        List<Fleet> temp_list = new List<Fleet>();
        temp_list = fleets.GetItems();

        temp_list[0].AddShipToFleet(ship);
        temp_list[1].AddShipToFleet(ship1);
        temp_list[1].AddShipToFleet(ship2);
        temp_list[2].AddShipToFleet(ship3);
        temp_list[2].AddShipToFleet(ship4);
        temp_list[2].AddShipToFleet(ship5);
        temp_list[3].AddShipToFleet(ship6);
        temp_list[3].AddShipToFleet(ship7);
        temp_list[3].AddShipToFleet(ship8);
        temp_list[3].AddShipToFleet(ship9);

        #endregion
    }

    public void RemoveFleets(List<int> fleets_to_remove)
    {
        //fleets.RemoveItems(fleets_to_remove);
    }

    public TravelLanes GetLane()
    {
        TravelLanes[] lanes = GetComponentsInChildren<TravelLanes>();
        return lanes[0];
    }

    public string GetName()
    {
        return planet_name;
    }

    public int GetMaxSupply()
    {
        return max_supply;
    }

    public Inventory<Fleet> GetInventory()
    {
        return fleets;
    }

    public TravelLanes GetTravelLanes()
    {
        return travel_lanes;
    }
}