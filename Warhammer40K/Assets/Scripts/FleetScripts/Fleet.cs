using UnityEngine;
using System.Collections.Generic;

public interface IFleetStats
{
    int GetSupplyConsumption();
}

public class Fleet : IFleetStats
{
    public int GetSupplyConsumption()
    {
        int amount_to_return = 0;

        foreach (Ship ship in ships.GetItems())
        {
            amount_to_return += ship.GetSupplyConsumption();
        }
        return amount_to_return;
    }

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

    
}
