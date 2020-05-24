using System.Linq;
using UnityEngine;
using InventoryEnums;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    private Card[] ship_cards;
    private int sibling_index;

    private SORTING_TYPE sorting_type;

    private void Start()
    {
        ship_cards = GetComponentsInChildren<Card>();
        #region Debugging Stuff
        ship_cards[2].ShipSetup("Iron Blood", ShipEnums.FACTION.IMPERIUM, ShipEnums.SHIP_CLASS.BATTLESHIP, 100000);
        ship_cards[2].CardSetup();

        ship_cards[3].ShipSetup("Lord Solar", ShipEnums.FACTION.IMPERIUM, ShipEnums.SHIP_CLASS.CRUISER, 60000);
        ship_cards[3].CardSetup();

        ship_cards[0].ShipSetup("Vigilant", ShipEnums.FACTION.IMPERIUM, ShipEnums.SHIP_CLASS.LIGHT_CRUISER, 40000);
        ship_cards[0].CardSetup();

        ship_cards[1].ShipSetup("Valiant", ShipEnums.FACTION.IMPERIUM, ShipEnums.SHIP_CLASS.FRIGATE, 15000);
        ship_cards[1].CardSetup();

        sorting_type = SORTING_TYPE.SPECIAL_TO_FRIGATE;
        Invoke("SortInventory", 5);
        #endregion
    }

    public void SetSortingType(SORTING_TYPE temp_sorting_type)
    {
        if(sorting_type != temp_sorting_type)
        {
            sorting_type = temp_sorting_type;
            SortInventory();
        }
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
                break;
            }
        }
        if (card_set == false)
        {
            ship_cards[ship_cards.Length + 1] = temp_card;
        }
        SortInventory();
    }

    private void SortInventory()
    {
        switch (sorting_type)
        {
            case SORTING_TYPE.FRIGATE_TO_SPECIAL:
                ship_cards = ship_cards.OrderBy(c => c.GetShipClass() - 8).ToArray();
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