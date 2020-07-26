using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetInventory : MonoBehaviour
{
    ///Local ship Inventory of planets

    private PlanetFleetMenu pfm;
    private Fleet[] fleet; //fleets present in system
    private UI_Inventory ui_inv; //ship inventory to the right

    private void Awake()
    {
        pfm = FindObjectOfType<Canvas>().GetComponentInChildren<PlanetFleetMenu>();
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
        //TODO: Find alternative for getcomponent
        pfm.SetPlanet(this.gameObject.GetComponent<PlanetInventory>());
    }
}
