using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private Card[] ship_cards;
    private Card[] temp_ship_card;

    public void SetShipCards(Card temp_card)
    {
        bool ship_set = false;
        for (int i = 0; i < ship_cards.Length; i++)
        {
            if (ship_cards[i] == null)
            {
                ship_cards[i] = temp_card;
                ship_set = true;
            }
        }
        if (ship_set == false)
        {
            ship_cards[ship_cards.Length + 1] = temp_card;
        }
    }

    public void SortInventory(int sort_type)
    {
        int current_ship_class = 0;
        int current_card_index = 0;
        Card[] temp_card_array = ship_cards;

        switch (sort_type)
        {
            case 1:
                //sorts ships by ship class from escort to special
                break;
            case 2:
                //sorts ships by ship class from special to escort
                break;
            case 3:
                //sorts ships by ship power
                break;
            case 4:
                //sorts ships by ship influence
                break;
        }

        for (int i = 0; i < 6; i++)
        {
            foreach (Card card in temp_card_array)
            {
                if (card.GetShipClassInt() == current_ship_class)
                {
                    ship_cards[current_card_index] = card;
                }
                current_card_index++;
            }
            current_ship_class++;
        }
    }

    private void SortingStyle()
    {

    }
}