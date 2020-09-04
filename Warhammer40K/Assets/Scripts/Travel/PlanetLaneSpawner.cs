using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetLaneSpawner : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        TravelLanes[] travel_lanes;
        travel_lanes = GetComponentsInChildren<TravelLanes>();

        foreach (TravelLanes travel in travel_lanes)
        {
            travel.Setup();
            yield return new WaitForSeconds(0.01f);
        }
    }
}

