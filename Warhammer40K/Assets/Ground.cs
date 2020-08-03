using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ground : MonoBehaviour
{
    [SerializeField] private UiCollision[] ui_collision;
    private PlanetFleetMenu planet_fleet_menu;

    private void Awake()
    {
        planet_fleet_menu = FindObjectOfType<Canvas>().GetComponentInChildren<PlanetFleetMenu>();
    }

    private void Start()
    {
        ui_collision[0] = GameObject.FindGameObjectWithTag("planet_fleet_menu").GetComponent<UiCollision>();
    }

    private void OnMouseDown()
    {
        if (ui_collision[0].isUIOverride)
        {
            Debug.Log("Cancelled OnMouseDown! A UI element has override this object!");
        }
        else
        {
            planet_fleet_menu.Clear();
        }
    }
}
