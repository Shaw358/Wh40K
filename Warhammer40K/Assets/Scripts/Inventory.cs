using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private Card[] ship_cards;
    private Card[] temp_ship_card;
    private bool ship_set = false;

    public void SetShipCards(Card temp_card)
    {
        for (int i = 0; i < ship_cards.Length; i++)
        {
            if (ship_cards[i] == null)
            {
                ship_cards[i] = temp_card;
                ship_set = true;
            }
        }
        if(ship_set == false)
        {
            ship_cards[ship_cards.Length + 1] = temp_card;
        }
    }

    private void SortInventory()
    {
        for(int i = 0; i < 6; i++)
        {

        }

        int index = 0;
        foreach(Card card in ship_cards)
        {
            ship_cards[index].GetShipClass();

            index++;
        }
    }
}
