using System.Linq;
using UnityEngine;
using InventoryEnums;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    private Card[] ship_cards;
    private int sibling_index;

    public SORTING_TYPE sorting_type;

    private void Start()
    {
        #region Debugging Stuff

        ship_cards[0].ShipSetup("", ShipEnums.FACTION.IMPERIUM, ShipEnums.SHIP_CLASS.);
        ship_cards[0].CardSetup();
        #endregion
    }

    public void SetSortingType(SORTING_TYPE temp_sorting_type)
    {
        sorting_type = temp_sorting_type;
        SortInventory();
    }

    public void AddCard(Card temp_card)
    {
        //TODO: Setup card/ship in function
        bool card_set = false;
        for (int i = 0; i < ship_cards.Length; i++)
        {
            if (ship_cards[i] == null)
            {
                ship_cards[i] = temp_card;
                card_set = true;
            }
        }
        if (card_set == false)
        {
            ship_cards[ship_cards.Length + 1] = temp_card;
        }
        SortInventory();
    }

    public void SortInventory()
    {
        switch (sorting_type)
        {
            case SORTING_TYPE.FRIGATE_TO_SPECIAL:
                ship_cards = ship_cards.OrderBy(c => c.GetShipClass() - 6).ToArray();
                break;
            case SORTING_TYPE.SPECIAL_TO_FRIGATE:
                ship_cards = ship_cards.OrderByDescending(c => c.GetShipClass()).ToArray();
                break;
            case SORTING_TYPE.POWER:
                //sorts ships by ship power
                ship_cards = ship_cards.OrderByDescending(c => c.GetShipPower()).ToArray();
                break;
            case SORTING_TYPE.INFLUENCE:
                //sorts ships by ship influence
                ship_cards = ship_cards.OrderByDescending(c => c.GetShipInfluence()).ToArray();
                break;
        }
        SortCardHierarchy();
    }

    private void SortCardHierarchy()
    {
        for(int i = 0; i < ship_cards.Length; i++)
        {
            ship_cards[i].gameObject.transform.SetSiblingIndex(i);
        }
    }
}