using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UiCollision : MonoBehaviour
{
    public bool isUIOverride { get; private set; }

    void Update()
    {
        // It will turn true if hovering any UI Elements
        isUIOverride = EventSystem.current.IsPointerOverGameObject();
    }
}
