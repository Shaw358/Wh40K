using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUiMovement : MonoBehaviour
{
    private RectTransform rectTrans;

    public Vector2 collapsed_state = new Vector2(1017, 392f);
    public Vector2 open_state = new Vector2(672, 392);
    
    private void Awake()
    {
        rectTrans = GetComponent<RectTransform>();
    }

    //TODO:
    //animate it
    public void Move()
    {
        if (rectTrans.anchoredPosition.x == 1017)
        {
            rectTrans.anchoredPosition = open_state;
        }
        else
        {
            rectTrans.anchoredPosition = collapsed_state;
        }
    }
}
