﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ShipEnums;

public class Ship : MonoBehaviour
{
    //basic stats
    protected float card_scale;
    protected int ID;
    protected string ship_name;
    protected string captain_name;
    protected FACTION faction;
    protected SHIP_CLASS ship_class;
    protected SHIP_LEVEL ship_level;

    public void ShipSetup(int temp_ID, string temp_ship_name, string temp_captain_name, FACTION temp_faction, SHIP_CLASS temp_ship_class)
    {
        ID = temp_ID;
        ship_name = temp_ship_name;
        captain_name = temp_captain_name;
        faction = temp_faction;
        ship_class = temp_ship_class;
    }

    public SHIP_CLASS GetShipClass()
    {
        return ship_class;
    }
}
