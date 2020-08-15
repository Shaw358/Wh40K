using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FleetCard : MonoBehaviour
{ 
    private PlanetFleetMenu pfm;
    private int supply_consumption;
    private int sibling_index;

    private void Awake()
    {
        pfm = GameObject.Find("planet_menu_container").GetComponent<PlanetFleetMenu>();
        sibling_index = transform.GetSiblingIndex();
    }

    private void OnMouseDown()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            pfm.CardTransferFleetSelector(PlanetFleetMenu.SELECTION_TYPE.SHIFT, sibling_index);
        }
        else if(Input.GetKey(KeyCode.LeftControl))
        {
            pfm.CardTransferFleetSelector(PlanetFleetMenu.SELECTION_TYPE.CONTROL, sibling_index);
        }
        else
        {
            pfm.CardTransferFleetSelector(PlanetFleetMenu.SELECTION_TYPE.SINGLE, sibling_index);
        }
    }
}
