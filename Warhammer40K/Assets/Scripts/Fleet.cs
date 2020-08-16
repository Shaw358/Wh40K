using UnityEngine;
using CardManagement;

public class Fleet : ScriptableObject
{
    private Card[] cards;
    private int supply_consumption;

    public Card GetCard(int index)
    {
        return cards[index];
    }

    public Card[] GetCards()
    {
        return cards;
    }

    public void AddCardToFleet(Card card_to_add)
    {
        cards[InventoryN.SearchEmptyIndex(cards)] = card_to_add; 
    }
}
