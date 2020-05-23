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
        ship_cards = GetComponentsInChildren<Card>();
        ship_cards[0].CardSetup("Cruiser");
        ship_cards[0].SetShipClass(ShipEnums.SHIP_CLASS.CRUISER);

        ship_cards[1].CardSetup("Escort");
        ship_cards[1].SetShipClass(ShipEnums.SHIP_CLASS.ESCORT);

        ship_cards[2].CardSetup("Battleship");
        ship_cards[2].SetShipClass(ShipEnums.SHIP_CLASS.BATTLESHIP);

        ship_cards[3].CardSetup("Special");
        ship_cards[3].SetShipClass(ShipEnums.SHIP_CLASS.SPECIAL);

        SetSortingType(SORTING_TYPE.ESCORT_TO_SPECIAL);
    }

    public void SetSortingType(SORTING_TYPE temp_sorting_type)
    {
        sorting_type = temp_sorting_type;
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
        SortInventory();
    }

    public void SortInventory()
    {
        switch (sorting_type)
        {
            case SORTING_TYPE.ESCORT_TO_SPECIAL:
                ship_cards = ship_cards.OrderBy(c => c.GetShipClass() - 6).ToArray();
                break;
            case SORTING_TYPE.SPECIAL_TO_ESCORT:
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
        StartCoroutine(SortCardHierarchyTemp());
    }

    private void SortCardHierarchy()
    {
        for(int i = 0; i < ship_cards.Length; i++)
        {
            ship_cards[i].gameObject.transform.SetSiblingIndex(i);
        }
    }

    private IEnumerator SortCardHierarchyTemp()
    {
        yield return new WaitForSeconds(1.5f);
        for (int i = 0; i < ship_cards.Length; i++)
        {
            ship_cards[i].gameObject.transform.SetSiblingIndex(i);
        }
    }
}