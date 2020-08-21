using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InventoryEnums;
using System.Linq;
using System;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    private static int max_cards_on_screen = 150;
    private List<Card> ship_cards = new List<Card>();
    private int sibling_index;

    private SORTING_TYPE curr_sorting_type = SORTING_TYPE.FRIGATE_TO_SPECIAL;

    private void Awake()
    {
        PullCards();
    }

    private void Start()
    {
        #region Debugging Stuff
        /*ship_cards[2].ShipSetup("Iron Blood", ShipEnums.FACTION.IMPERIUM, ShipEnums.SHIP_CLASS.BATTLESHIP, 100000);
       ship_cards[2].CardSetInfo();

       ship_cards[3].ShipSetup("Lord Solar", ShipEnums.FACTION.IMPERIUM, ShipEnums.SHIP_CLASS.CRUISER, 60000);
       ship_cards[3].CardSetInfo();

       ship_cards[0].ShipSetup("Vigilant", ShipEnums.FACTION.IMPERIUM, ShipEnums.SHIP_CLASS.LIGHT_CRUISER, 40000);
       ship_cards[0].CardSetInfo();

       ship_cards[1].ShipSetup("Valiant", ShipEnums.FACTION.IMPERIUM, ShipEnums.SHIP_CLASS.FRIGATE, 15000);
       ship_cards[1].CardSetInfo();

       for(int i = 0; i < ship_cards.Length; i++)
       {
           ship_cards[i].ShipSetup("Testing", ShipEnums.FACTION.IMPERIUM, ShipEnums.SHIP_CLASS.SPECIAL, 1);
           ship_cards[i].CardSetInfo();
       }

       UpdateCardInventory(null, curr_sorting_type);
       */
        #endregion
    }

    public void UpdateCardInventory(Ship[] ship_array = null, SORTING_TYPE sorting_type = SORTING_TYPE.NONE) //This will sort the cards array on the Sorting Type
    {
        Ship[] temp_ship_array;

        //checks if the it should sort a new set of cards or just the current ones
        {
            temp_ship_array = ship_array;

            //to reset the game objects for a showing a new bunch of cards
            for (int i = 0; i < ship_cards.Count; i++)
            {
                ship_cards[i].gameObject.SetActive(false);
            }
        }

        if (sorting_type == SORTING_TYPE.NONE)
        {
            sorting_type = curr_sorting_type;
        }

        //to reset the array for new cards
        //Array.Clear(cards, 0, cards.Length);

        switch (sorting_type)
        {
            case SORTING_TYPE.FRIGATE_TO_SPECIAL:
                //sorts ships by Frigate to Special
                temp_ship_array = temp_ship_array.OrderBy(c => c.GetShipClass() - Enum.GetNames(typeof(SORTING_TYPE)).Length - 1).ToArray();
                break;
            case SORTING_TYPE.SPECIAL_TO_FRIGATE:
                //sorts ships by Special to Frigate
                temp_ship_array = temp_ship_array.OrderByDescending(c => c.GetShipClass()).ToArray();
                break;
            case SORTING_TYPE.POWER:
                //sorts ships by ship power
                temp_ship_array = temp_ship_array.OrderByDescending(c => c.GetShipPower()).ToArray();
                break;
            case SORTING_TYPE.INFLUENCE:
                //sorts ships by ship influence
                temp_ship_array = temp_ship_array.OrderByDescending(c => c.GetShipInfluence()).ToArray();
                break;
        }

        for (int i = 0; i < temp_ship_array.Length; i++)
        {
            ship_cards[i].gameObject.SetActive(true);
            ship_cards[i].UpdateCardInfo(ship_array[i]);
        }
        SortCardHierarchy();
    }

    private void SortCardHierarchy()
    {
        for (int i = 0; i < ship_cards.Count; i++)
        {
            ship_cards[i].gameObject.transform.SetSiblingIndex(i);
        }
    }

    private void PullCards()
    {
        ship_cards.AddRange(transform.GetComponentsInChildren<Card>());
    }
}