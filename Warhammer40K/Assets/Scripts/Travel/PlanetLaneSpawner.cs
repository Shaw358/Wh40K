using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetLaneSpawner : MonoBehaviour
{

    TravelLanes[] travel_lanes;

    private void Start()
    {
        travel_lanes = GetComponentsInChildren<TravelLanes>();
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        foreach(TravelLanes travel in travel_lanes)
        {
            travel.Setup();
            yield return new WaitForSeconds(0.01f);
        }
    }
}

