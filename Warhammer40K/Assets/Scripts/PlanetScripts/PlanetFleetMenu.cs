using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlanetFleetMenu : MonoBehaviour
{
    private Vector3 position_correction;
    [SerializeField] private GameObject curr_planet;

    private void Start()
    {
        position_correction = new Vector3(3, 0, 0);
    }

    private void Update()
    {
        transform.position = Camera.main.WorldToScreenPoint(curr_planet.transform.position + position_correction);
    }
}
