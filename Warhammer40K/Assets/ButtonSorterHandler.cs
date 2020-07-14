using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSorterHandler : MonoBehaviour
{
    public UI_Inventory ui_inv;

    public void ChangeSortingType(int index)
    {
        switch(index)
        {
            case 0:
                ui_inv.SortInventory(InventoryEnums.SORTING_TYPE.FRIGATE_TO_SPECIAL);
                break;
            case 1:
                ui_inv.SortInventory(InventoryEnums.SORTING_TYPE.SPECIAL_TO_FRIGATE);
                break;
            case 2:
                ui_inv.SortInventory(InventoryEnums.SORTING_TYPE.INFLUENCE);
                break;
            case 3:
                ui_inv.SortInventory(InventoryEnums.SORTING_TYPE.POWER);
                break;
        }
    }
}
