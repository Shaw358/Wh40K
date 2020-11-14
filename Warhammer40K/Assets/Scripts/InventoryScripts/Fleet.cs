using UnityEngine;
using System.Collections.Generic;

public class Fleet : ScriptableObject
{
    //private List<Ship> ships = new List<Ship>();
    private Inventory<Ship> ships = new Inventory<Ship>();
    private int supply_consumption;

    //private Inventory

    public Ship GetShip(int index)
    {
        return ships.GetItem(index);
    }

    public List<Ship> GetShips()
    {
        return ships.GetItems();
    }

    public void AddShipToFleet(Ship ship_to_add)
    {
        ships.AddItem(ship_to_add); 
    }

    public int GetFleetSupplyConsumption()
    {
        int amount_to_return = 0;

        foreach(Ship ship in ships.GetItems())
        {
            amount_to_return += ship.GetSupplyConsumption();
        }
        return amount_to_return;
    }
}
