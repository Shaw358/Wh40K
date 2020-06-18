using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InventoryEnums;
using System.Linq;
using CardManagement;
using System;

public class UI_Inventory : MonoBehaviour
{
    private Card[] cards;
    private int sibling_index;

    private SORTING_TYPE sorting_type;

    private void Start()
    {
        cards = GetComponentsInChildren<Card>();
        GetCardsInHierarchy();
        #region Debugging Stuff
        cards[2].ShipSetup("Iron Blood", ShipEnums.FACTION.IMPERIUM, ShipEnums.SHIP_CLASS.BATTLESHIP, 100000);
        cards[2].CardSetup();

        cards[3].ShipSetup("Lord Solar", ShipEnums.FACTION.IMPERIUM, ShipEnums.SHIP_CLASS.CRUISER, 60000);
        cards[3].CardSetup();

        cards[0].ShipSetup("Vigilant", ShipEnums.FACTION.IMPERIUM, ShipEnums.SHIP_CLASS.LIGHT_CRUISER, 40000);
        cards[0].CardSetup();

        cards[1].ShipSetup("Valiant", ShipEnums.FACTION.IMPERIUM, ShipEnums.SHIP_CLASS.FRIGATE, 15000);
        cards[1].CardSetup();

        sorting_type = SORTING_TYPE.SPECIAL_TO_FRIGATE;
        Invoke("SortInventory", 5);
        #endregion
    }

    public void SetSortingType(SORTING_TYPE temp_sorting_type)
    {
        if (sorting_type != temp_sorting_type)
        {
            sorting_type = temp_sorting_type;
            SortInventory();
        }
    }

    public void AddCard(Card temp_card)
    {
        cards[InventoryN.SearchEmptyIndex(cards)] = temp_card;
        SortInventory();
    }

    private void SortInventory() //This will sort the cards array on the Sorting Type
    {
        switch (sorting_type)
        {
            case SORTING_TYPE.FRIGATE_TO_SPECIAL:
                //sorts ships by Frigate to Special
                cards = cards.OrderBy(c => c.GetShipClass() - Enum.GetNames(typeof(SORTING_TYPE)).Length).ToArray();
                break;
            case SORTING_TYPE.SPECIAL_TO_FRIGATE:
                //sorts ships by Special to Frigate
                cards = cards.OrderByDescending(c => c.GetShipClass()).ToArray();
                break;
            case SORTING_TYPE.POWER:
                //sorts ships by ship power
                cards = cards.OrderByDescending(c => c.GetShipPower()).ToArray();
                break;
            case SORTING_TYPE.INFLUENCE:
                //sorts ships by ship influence
                cards = cards.OrderByDescending(c => c.GetShipInfluence()).ToArray();
                break;
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

    private void GetCardsInHierarchy() //only supposed to be called once at the start of the game
    {
        cards = GetComponentsInChildren<Card>();
    }
}
