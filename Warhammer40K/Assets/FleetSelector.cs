using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleetSelector
{
    private UI_Inventory ui_inv;

    public void Setup()
    {
        ui_inv = GameObject.Find("all_ship_cards").GetComponent<UI_Inventory>();
    }

    public void SetCards(List<Fleet> fleets)
    {
        List<Ship> temp_ship_list = new List<Ship>();

        Debug.Log(fleets[0].GetShips());

        foreach (Fleet fleet in fleets)
        {
            temp_ship_list.AddRange(fleet.GetShips());
        }
        ui_inv.UpdateCardInventory(temp_ship_list);
    }
}
