using System.Collections.Generic;
using UnityEngine;
using Factions;
using TMPro;
using Planets;

public class Planet : MonoBehaviour
{
    /// <summary>
    /// Overall class to keep track of basic stats that belong on every planet
    /// </summary>

    protected FACTION faction = FACTION.PLAYER;
    protected int max_supply;
    private Inventory<Fleet> fleets = new Inventory<Fleet>();
    [SerializeField] TextMeshPro name_text_mesh;

    [SerializeField] protected string planet_name;
    private TravelLanes travel_lanes;
    private bool empire_capital = false;

    //protected List<Fleet> fleets = new List<Fleet>(); //fleets present in system

    private void Awake()
    {
        name_text_mesh = transform.parent.GetComponentInChildren<TextMeshPro>();
        max_supply = 10;
        travel_lanes = GetComponentInChildren<TravelLanes>();
        TextColor();

        #region deubbing
        fleets.AddItem(new Fleet());
        fleets.AddItem(new Fleet());
        fleets.AddItem(new Fleet());
        fleets.AddItem(new Fleet());

        Ship ship = (Ship)ScriptableObject.CreateInstance(typeof(Ship));
        ship.ShipSetup("HMS Indomitable", ShipEnums.FACTION.IMPERIUM, ShipEnums.SHIP_CLASS.BATTLESHIP, 1000);
        Ship ship1 = (Ship)ScriptableObject.CreateInstance(typeof(Ship));
        ship1.ShipSetup("HMS henk", ShipEnums.FACTION.IMPERIUM, ShipEnums.SHIP_CLASS.BATTLESHIP, 2000);

        Ship ship2 = (Ship)ScriptableObject.CreateInstance(typeof(Ship));
        ship2.ShipSetup("HMS Hammer", ShipEnums.FACTION.IMPERIUM, ShipEnums.SHIP_CLASS.CRUISER, 3000);

        Ship ship3 = (Ship)ScriptableObject.CreateInstance(typeof(Ship));
        ship3.ShipSetup("HMS Cruiser", ShipEnums.FACTION.IMPERIUM, ShipEnums.SHIP_CLASS.LIGHT_CRUISER, 4000);
        Ship ship4 = (Ship)ScriptableObject.CreateInstance(typeof(Ship));
        ship4.ShipSetup("HMS ThunderChild", ShipEnums.FACTION.IMPERIUM, ShipEnums.SHIP_CLASS.FRIGATE, 5000);

        Ship ship5 = (Ship)ScriptableObject.CreateInstance(typeof(Ship));
        ship5.ShipSetup("HMS Lawnmower", ShipEnums.FACTION.IMPERIUM, ShipEnums.SHIP_CLASS.DESTROYER, 6000);

        Ship ship6 = (Ship)ScriptableObject.CreateInstance(typeof(Ship));
        ship6.ShipSetup("HMS Dreadnought", ShipEnums.FACTION.IMPERIUM, ShipEnums.SHIP_CLASS.SPECIAL, 7000);
        Ship ship7 = (Ship)ScriptableObject.CreateInstance(typeof(Ship));
        ship7.ShipSetup("HMS God i wish i was good at Frontend", ShipEnums.FACTION.IMPERIUM, ShipEnums.SHIP_CLASS.BATTLE_CRUISER, 8000);

        Ship ship8 = (Ship)ScriptableObject.CreateInstance(typeof(Ship));
        ship8.ShipSetup("HMS Michael Jackson", ShipEnums.FACTION.IMPERIUM, ShipEnums.SHIP_CLASS.CRUISER, 9000);
        Ship ship9 = (Ship)ScriptableObject.CreateInstance(typeof(Ship));
        ship9.ShipSetup("HMS Sabaton", ShipEnums.FACTION.IMPERIUM, ShipEnums.SHIP_CLASS.CRUISER, 10000);

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

    public void SetFaction(FACTION new_faction)
    {
        faction = new_faction;
        TextColor();
    }

    public FACTION GetFaction()
    {
        return faction;
    }

    public void SetPlanetName(string new_name)
    {
        planet_name = new_name;
        name_text_mesh.text = planet_name;
    }

    public void TextColor()
    {
        byte r = 0;
        byte g = 0;
        byte b = 0;
        byte a = 255;
        switch (faction)
        {
            case FACTION.ENEMY:
                r = 255;
                g = 0;
                b = 0;
                name_text_mesh.color = new Color32(r, g, b, a);
                break;
            case FACTION.PLAYER:
                r = 47;
                g = 74;
                b = 255;
                name_text_mesh.color = new Color32(r, g, b, a);
                break;
        }
    }

    public void SetEmpireCapital(bool state)
    {
        empire_capital = state;
    }
}