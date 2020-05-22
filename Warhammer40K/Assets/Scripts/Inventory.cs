using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private Card[] ship_cards;

    private void Start()
    {
        #region Debug Purposes
        ship_cards = GetComponentsInChildren<Card>();
        ship_cards[0].SetShipClass(ShipEnums.SHIP_CLASS.SPECIAL);
        ship_cards[1].SetShipClass(ShipEnums.SHIP_CLASS.ESCORT);
        ship_cards[2].SetShipClass(ShipEnums.SHIP_CLASS.BATTLESHIP);
        ship_cards[3].SetShipClass(ShipEnums.SHIP_CLASS.CRUISER);

        for (int i = 0; i < ship_cards.Length; i++)
        {
            print(ship_cards[i].GetShipClass().ToString());
        }
        SortInventory(0);
        #endregion
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

    public void SortInventory(SORTING_TYPE sorting_type)
    {
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

        //TODO: Sorting Fix, only sorts from escort to special right now

        switch (sorting_type)
        {
            case SORTING_TYPE.ESCORT_TO_SPECIAL:
                //sorts ships by ship class from escort to special
                break;
            case SORTING_TYPE.SPECIAL_TO_SMALL:
                //sorts ships by ship class from special to escort
                break;
            case SORTING_TYPE.POWER:
                //sorts ships by ship power
                break;
            case SORTING_TYPE.INFLUENCE:
                //sorts ships by ship influence
                break;
        }

    }

    private void SortingStyle()
    {

    }
}