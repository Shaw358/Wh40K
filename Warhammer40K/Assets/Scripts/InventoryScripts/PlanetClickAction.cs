using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetClickAction : MonoBehaviour
{
    private PlanetFleetMenu pfm;
        
    private void Awake()
    {
        pfm = GameObject.Find("planet_menu_container").GetComponent<PlanetFleetMenu>();
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pfm.Activate(gameObject.GetComponent<Planet>());
        }
        if (Input.GetMouseButtonDown(1))
        {
            Planet planet = GetComponent<Planet>();
            pfm.MoveFleetOnMap(planet);
        }
    }
}
