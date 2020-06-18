using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CardManagement;

public class Fleet : MonoBehaviour
{
    private Card[] cards;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public Card GetCard(int index)
    {
        return cards[index];
    }

    public void AddCardToFleet(Card temp_card)
    {
        cards[InventoryN.SearchEmptyIndex(cards)] = temp_card; 
    }
}
