using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleetSelector
{
    UI_Inventory ui_inv;


    private void Awake()
    {
        ui_inv = GameObject.Find("all_ship_cards").GetComponent<UI_Inventory>();
    }

    public void SetCards(Fleet[] fleets)
    {
        List<Card> temp_card_list = new List<Card>();

        foreach(Fleet fleet in fleets)
        {
            temp_card_list.AddRange(fleet.GetCards());
        }
        Card[] ship_cards = temp_card_list.ToArray();

        ui_inv.UpdateCardInventory(ship_cards);
    }
}
