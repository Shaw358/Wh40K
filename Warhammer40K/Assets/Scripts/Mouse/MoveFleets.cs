using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFleets : MonoBehaviour
{
    private PlanetFleetMenu pfm;

    private void Awake()
    {
        pfm = GameObject.Find("planet_menu_container").GetComponent<PlanetFleetMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
