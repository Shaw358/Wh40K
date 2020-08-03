using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InventoryEnums;
using System.Linq;
using System;

public class UI_Inventory : MonoBehaviour
{
    private static int max_cards_on_screen = 150;
    private Card[] cards;
    private int sibling_index;

    private SORTING_TYPE curr_sorting_type = SORTING_TYPE.FRIGATE_TO_SPECIAL;

    private void Awake()
    {
        PullCards();
    }

    private void Start()
    {
        #region Debugging Stuff
        cards[2].ShipSetup("Iron Blood", ShipEnums.FACTION.IMPERIUM, ShipEnums.SHIP_CLASS.BATTLESHIP, 100000);
        cards[2].CardSetup();

        cards[3].ShipSetup("Lord Solar", ShipEnums.FACTION.IMPERIUM, ShipEnums.SHIP_CLASS.CRUISER, 60000);
        cards[3].CardSetup();

        cards[0].ShipSetup("Vigilant", ShipEnums.FACTION.IMPERIUM, ShipEnums.SHIP_CLASS.LIGHT_CRUISER, 40000);
        cards[0].CardSetup();

        cards[1].ShipSetup("Valiant", ShipEnums.FACTION.IMPERIUM, ShipEnums.SHIP_CLASS.FRIGATE, 15000);
        cards[1].CardSetup();

        for(int i = 0; i < 147; i++)
        {
            cards[i].ShipSetup("Testing", ShipEnums.FACTION.IMPERIUM, ShipEnums.SHIP_CLASS.SPECIAL, 1);
            cards[i].CardSetup();
        }

        SortInventory(curr_sorting_type);
        #endregion
    }

    public void SortInventory(SORTING_TYPE sorting_type = SORTING_TYPE.NONE, Card[] card_array = null) //This will sort the cards array on the Sorting Type
    {
        Card[] temp_card_array;

        //checks if the it should sort a new set of cards or just the current ones
        if (card_array == null)
        {
            temp_card_array = cards;
        }
        else
        {
            temp_card_array = card_array;

            //to reset the game objects for a showing a new bunch of cards
            for (int i = 0; i < cards.Length; i++)
            {
                cards[i].gameObject.SetActive(false);
            }
        }

        if(sorting_type == SORTING_TYPE.NONE)
        {
            sorting_type = curr_sorting_type;
        }

        //to reset the array for new cards
        //Array.Clear(cards, 0, cards.Length);

        switch (sorting_type)
        {
            case SORTING_TYPE.FRIGATE_TO_SPECIAL:
                //sorts ships by Frigate to Special
                temp_card_array = temp_card_array.OrderBy(c => c.GetShipClass() - Enum.GetNames(typeof(SORTING_TYPE)).Length - 1).ToArray();
                break;
            case SORTING_TYPE.SPECIAL_TO_FRIGATE:
                //sorts ships by Special to Frigate
                temp_card_array = temp_card_array.OrderByDescending(c => c.GetShipClass()).ToArray();
                break;
            case SORTING_TYPE.POWER:
                //sorts ships by ship power
                temp_card_array = temp_card_array.OrderByDescending(c => c.GetShipPower()).ToArray();
                break;
            case SORTING_TYPE.INFLUENCE:
                //sorts ships by ship influence
                temp_card_array = temp_card_array.OrderByDescending(c => c.GetShipInfluence()).ToArray();
                break;
        }
        
        for(int i = 0; i < temp_card_array.Length; i++)
        {
            cards[i].gameObject.SetActive(true);
            cards[i] = temp_card_array[i];
        }
        SortCardHierarchy();
    }

    private void SortCardHierarchy()
    {
        for (int i = 0; i < cards.Length; i++)
        {
            cards[i].gameObject.transform.SetSiblingIndex(i);
        }
    }

    private void PullCards()
    {
        cards = GetComponentsInChildren<Card>();
    }
}