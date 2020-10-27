using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUiMovement : MonoBehaviour
{
    private RectTransform rect_trans;

    private bool is_active;

    public Vector2 collapsed_state = new Vector2(1017, 392f);
    public Vector2 open_state = new Vector2(672, 392);
    
    private void Awake()
    {
        is_active = true;
        rect_trans = GetComponent<RectTransform>();
    }

    //TODO:
    //animate it
    public void Move()
    {
        if (is_active == true)
        {
            rect_trans.anchoredPosition = collapsed_state;
            is_active = false;
        }
        else
        {
            rect_trans.anchoredPosition = open_state;
            is_active = true;
        }
    }

    public void Enable(bool temp_is_active)
    {
        is_active = temp_is_active;
        Move();
    }
}

