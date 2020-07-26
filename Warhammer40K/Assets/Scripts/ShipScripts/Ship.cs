using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ShipEnums;

public class Ship : MonoBehaviour
{
    //basic stats
    protected float card_scale;
    private int power;
    private int influence;
    private Captain captain;
    protected string ship_name;
    protected FACTION faction;
    protected SHIP_CLASS ship_class;
    protected SHIP_LEVEL ship_level;
    protected ObjectHealth object_health;

    public void ShipSetup(string temp_ship_name, FACTION temp_faction, SHIP_CLASS temp_ship_class, int temp_health)
    {
        captain = new Captain();
        object_health = new ObjectHealth();
        object_health.SetHealth(temp_health);

        ship_name = "The " + temp_ship_name;
        faction = temp_faction;
        ship_class = temp_ship_class;

    }

    public int GetShipClassInt()
    {
        return (int)ship_class;
    }

    public int GetShipPower()
    {
        return power;
    }

    public int GetShipInfluence()
    {
        return influence;
    }

    public SHIP_CLASS GetShipClass()
    {
        return ship_class;
    }

    public void SetShipClass(SHIP_CLASS temp_ship_class)
    {
        ship_class = temp_ship_class;
    }
}
