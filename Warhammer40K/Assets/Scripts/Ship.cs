using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ShipEnums;

public class Ship : MonoBehaviour
{
    //basic stats
    protected float card_scale;
    protected int ID;
    private int power;
    private int influence;
    private Captain captain;
    protected string ship_name;
    protected FACTION faction;
    protected SHIP_CLASS ship_class;
    protected SHIP_LEVEL ship_level;

    public void ShipSetup(int temp_ID, string temp_ship_name, FACTION temp_faction, SHIP_CLASS temp_ship_class)
    {
        ID = temp_ID;
        ship_name = temp_ship_name;
        faction = temp_faction;
        ship_class = temp_ship_class;
        captain = new Captain();
    }

    public int GetShipClassInt()
    {
        return (int)ship_class;
    }

    public void SetShipPower(int temp_power)
    {
        power = temp_power;
    }

    public int GetShipPower()
    {
        return power;
    }

    public void SetShipInfluence(int temp_influence)
    {
        influence = temp_influence;
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
