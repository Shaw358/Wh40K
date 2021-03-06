﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSorterHandler : MonoBehaviour
{
    public UI_Inventory ui_inv;

    private void Awake()
    {
        ui_inv = GameObject.Find("all_ship_cards").GetComponent<UI_Inventory>();
    }

    public void ChangeSortingType(int index)
    {
        switch(index)
        {
            case 0:
                ui_inv.UpdateCardInventory(null, InventoryEnums.SORTING_TYPE.FRIGATE_TO_SPECIAL);
                break;
            case 1:
                ui_inv.UpdateCardInventory(null, InventoryEnums.SORTING_TYPE.SPECIAL_TO_FRIGATE);
                break;
            case 2:
                ui_inv.UpdateCardInventory(null, InventoryEnums.SORTING_TYPE.INFLUENCE);
                break;
            case 3:
                ui_inv.UpdateCardInventory(null, InventoryEnums.SORTING_TYPE.POWER);
                break;
        }
    }
}
