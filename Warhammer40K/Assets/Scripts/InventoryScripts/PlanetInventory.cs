using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetInventory : MonoBehaviour
{
    ///Local ship Inventory of planets
   
    private Fleet[] fleet; //fleets present in system
    private UI_Inventory ui_inv; //ship inventory to the right

    private void Awake()
    {
        ui_inv = GameObject.Find("all_ship_cards").GetComponent<UI_Inventory>();
    }

    public Fleet[] GetFleets()
    {
        return fleet;
    }

    public Card[] GetCardsFromFleet(int index)
    {
        return fleet[index].GetCards();
    }

    private void OnMouseDown()
    {
        print("click");
    }
}
