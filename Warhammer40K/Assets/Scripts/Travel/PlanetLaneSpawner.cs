using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetLaneSpawner : MonoBehaviour
{
    /// <summary>
    /// This class will spawn visible lanes from planet to planet to see which path your fleets will take
    /// </summary>
    private void Start()
    {
        StartCoroutine(Spawn());
        gameObject.GetComponent<PlanetCollection>().GetAllPlanets();
    }

    //Spawns the lines with a slight delay in order to allow each TravelLanes to update onto which planets it has already connected
    private IEnumerator Spawn()
    {
        TravelLanes[] travel_lanes;
        travel_lanes = GetComponentsInChildren<TravelLanes>();
        int i = 0;
        foreach (TravelLanes travel in travel_lanes)
        {
            i++;
            try
            {
                transform.GetChild(i).name = "Planet " + i;
            }
            catch
            {

            }
           
            travel.Setup();
            yield return new WaitForSeconds(0.01f);
        }
    }
}

