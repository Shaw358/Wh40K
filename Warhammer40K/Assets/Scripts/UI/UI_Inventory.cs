using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InventoryEnums;
using System.Linq;
using System;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    //private static int max_cards_on_screen = 150;
    private List<Card> ship_cards = new List<Card>();
    private List<Ship> ships = new List<Ship>();
    private int sibling_index;

    private SORTING_TYPE curr_sorting_type;

    private void Awake()
    {
        PullCards();
        curr_sorting_type = SORTING_TYPE.SPECIAL_TO_FRIGATE;
    }

    public void UpdateCardInventory(List<Ship> ship_list = null, SORTING_TYPE sorting_type = SORTING_TYPE.NONE) //This will sort the cards array on the Sorting Type
    {
        if(ship_list != null)
        {
            ships = ship_list;
        }
        //to reset the game objects for a showing a new bunch of cards
        for (int i = 0; i < ship_cards.Count; i++)
        {
            ship_cards[i].gameObject.SetActive(false);
        }

        //checks if it should sort a new set of cards or just the current ones

        if (sorting_type == SORTING_TYPE.NONE)
        {
            sorting_type = curr_sorting_type;
        }
        else
        {
            curr_sorting_type = sorting_type;
        }

        switch (sorting_type)
        {
            case SORTING_TYPE.FRIGATE_TO_SPECIAL:
                //sorts ships by Frigate to Special
                ships = ships.OrderBy(c => c.GetShipClass() - Enum.GetNames(typeof(SORTING_TYPE)).Length - 1).ToList();
                break;
            case SORTING_TYPE.SPECIAL_TO_FRIGATE:
                //sorts ships by Special to Frigate
                ships = ships.OrderByDescending(c => c.GetShipClass()).ToList();
                break;
            case SORTING_TYPE.POWER:
                //sorts ships by ship power
                ships = ships.OrderByDescending(c => c.GetShipPower()).ToList();
                break;
            case SORTING_TYPE.INFLUENCE:
                //sorts ships by ship influence
                ships = ships.OrderByDescending(c => c.GetShipInfluence()).ToList();
                break;
        }

        for (int i = 0; i < ships.Count; i++)
        {
            ship_cards[i].gameObject.SetActive(true);
            ship_cards[i].UpdateCardInfo(ships[i]);
        }
        SortCardHierarchy();
    }

    //shows the sorted cards to the player by changing the gameobject hierarchy
    private void SortCardHierarchy()
    {
        for (int i = 0; i < ship_cards.Count; i++)
        {
            ship_cards[i].gameObject.transform.SetSiblingIndex(i);
        }
    }

    //gets all cards once
    private void PullCards()
    {
        ship_cards.AddRange(transform.GetComponentsInChildren<Card>());
    }
}