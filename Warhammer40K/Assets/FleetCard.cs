using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FleetCard : MonoBehaviour
{
    private int supply_consumption;
    private int sibling_index;

    private void Awake()
    {
        sibling_index = transform.GetSiblingIndex();
    }

    public int ButtonPressed()
    {
        return sibling_index;
    }

    private void OnMouseDown()
    {
        
    }
}
