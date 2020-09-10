using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleetSelector
{
    /// <summary>
    /// This class just acts as a middleman
    /// </summary>
    private UI_Inventory ui_inv;

    public void Setup()
    {
        ui_inv = GameObject.Find("all_ship_cards").GetComponent<UI_Inventory>();
    }

    //Gets all the ships from the selected fleets to be sorted in the UI_Inventory class
    public void SetFleets(List<Fleet> fleets)
    {
        List<Ship> temp_ship_list = new List<Ship>();

        foreach (Fleet fleet in fleets)
        {
            temp_ship_list.AddRange(fleet.GetShips());
        }
        ui_inv.UpdateCardInventory(temp_ship_list);
    }
}
