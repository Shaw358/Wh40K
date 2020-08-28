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

    public List<Ship> GetShips()
    {
        return ships;
    }

    public void AddShipToFleet(Ship ship_to_add)
    {
        ships.Add(ship_to_add); 
    }

    public int GetFleetSupplyConsumption()
    {
        int amount_to_return = 0;

        foreach(Ship ship in ships)
        {
            amount_to_return += ship.GetSupplyConsumption();
        }
        return amount_to_return;
    }
}
