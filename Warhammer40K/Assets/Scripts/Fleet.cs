using UnityEngine;
using CardManagement;
using System.Collections.Generic;

public class Fleet : ScriptableObject
{
    private List<Ship> ships = new List<Ship>();
    private int supply_consumption;

    public Ship GetShips(int index)
    {
        return ships[index];
    }

    public Ship[] GetShips()
    {
        return ships.ToArray();
    }

    public void AddShipToFleet(Ship ship_to_add)
    {
        ships.Add(ship_to_add); 
    }
}
