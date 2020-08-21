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

    public void SetCards(Fleet[] fleets)
    {
        Debug.Log(ui_inv.gameObject.name);
        List<Ship> temp_ship_list = new List<Ship>();

        foreach(Fleet fleet in fleets)
        {
            temp_ship_list.AddRange(fleet.GetShips());
        }
        Ship[] ship_cards = temp_ship_list.ToArray();

        ui_inv.UpdateCardInventory(ship_cards);
    }
}
