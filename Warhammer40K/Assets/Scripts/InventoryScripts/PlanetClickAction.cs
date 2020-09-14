using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetClickAction : MonoBehaviour
{
    private PlanetFleetMenu pfm;
        
    private void Awake()
    {
        pfm = GameObject.FindGameObjectWithTag("planet_fleet_menu").GetComponentInChildren<PlanetFleetMenu>();
    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pfm.Activate(gameObject.GetComponent<Planet>());
        }
        if (Input.GetMouseButtonDown(1))
        {
            TravelLanes[] lanes = GetComponentsInChildren<TravelLanes>();
            pfm.MoveFleetOnMap(lanes[0]);
        }
    }
}
