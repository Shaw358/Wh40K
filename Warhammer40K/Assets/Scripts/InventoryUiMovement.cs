using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUiMovement : MonoBehaviour
{
    private RectTransform rectTrans;

    public Vector2 collapsed_state = new Vector2(1040, 392f);
    public Vector2 open_state = new Vector2(550, 392);
    
    private void Awake()
    {
        rectTrans = GetComponent<RectTransform>();
    }

    //TODO:
    //animate it
    public void Move()
    {
        if (rectTrans.anchoredPosition.x == 1040)
        {
            rectTrans.anchoredPosition = open_state;
        }
        else
        {
            rectTrans.anchoredPosition = collapsed_state;
        }
    }
}
