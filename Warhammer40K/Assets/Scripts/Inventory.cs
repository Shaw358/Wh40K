﻿using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private Card[] ship_cards;

    private void Start()
    {
        ship_cards = GetComponentsInChildren<Card>();
        ship_cards[0].SetShipClass(ShipEnums.SHIP_CLASS.SPECIAL);
        ship_cards[1].SetShipClass(ShipEnums.SHIP_CLASS.ESCORT);
        ship_cards[2].SetShipClass(ShipEnums.SHIP_CLASS.BATTLESHIP);
        ship_cards[3].SetShipClass(ShipEnums.SHIP_CLASS.CRUISER);

        for (int i = 0; i < ship_cards.Length; i++)
        {
            print(ship_cards[i].GetShipClass().ToString());
        }
        SortInventory();
    }

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

    public void SortInventory(/*int sort_type*/)
    {
        print("");
        ship_cards = ship_cards.OrderByDescending(c => c.GetShipClass()).ToArray();
        for (int i = 0; i < ship_cards.Length; i++)
        {
            print(ship_cards[i].GetShipClass().ToString());
        }
        print("");
        ship_cards = ship_cards.OrderBy(c => c.GetShipClass() - 6).ToArray();
        for (int i = 0; i < ship_cards.Length; i++)
        {
            print(ship_cards[i].GetShipClass().ToString());
        }
        /*
        int current_ship_class = 0;
        int current_card_index = 0;
        Card[] temp_card_array = ship_cards;

        //TODO: Sorting Fix, only sorts from escort to special right now

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

        /*
        for (int i = 0; i < 7; i++)
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
        */

    }

    private void SortingStyle()
    {

    }
}