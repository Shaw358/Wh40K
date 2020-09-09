using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFleet : MonoBehaviour
{
    private List<Fleet> fleet_to_transfer = new List<Fleet>();
    private List<PlanetInventory> all_planets = new List<PlanetInventory>();
    private List<GameObject> path = new List<GameObject>();
    private TravelLanes target_planet;

    private int distance_threshold

    private int current_planet_index = 0;

    private enum STATES
    {
        ACTIVE,
        NOT_ACTIVE,
        NONE
    }

    private STATES state = STATES.NOT_ACTIVE;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public void ClearFleets()
    {
        fleet_to_transfer.Clear();
    }

    public void Activate(List<Fleet> fleets, TravelLanes target, TravelLanes spawn_planet)
    {
        target_planet = target;
        fleet_to_transfer.AddRange(fleets);
        SearchFastestPath(spawn_planet);
    }

    private void SearchFastestPath(TravelLanes first_planet)
    {
        TravelLanes curr_planet = first_planet;
        PlanetInventory lowest_distance_planet = null;
        float lowest_distance_value = 0;

        foreach(PlanetInventory acc_planets in first_planet.GetAccessiblePlanets())
        {
            float distance = Vector3.Distance(acc_planets.transform.position, curr_planet.gameObject.transform.position);
            if(distance != 0)
            {
                if(distance < lowest_distance_value)
                {
                    lowest_distance_planet = acc_planets;
                    lowest_distance_value = distance;
                }
            }
            else
            {
                lowest_distance_planet = acc_planets;
                lowest_distance_value = distance;
            }
        }

        path.Add(lowest_distance_planet.gameObject);

        while (true)
        {


            break;
        }
        //path.Add()
        state = STATES.ACTIVE;
    }

    private void Update()
    {
        if(state == STATES.ACTIVE)
        {
            if(Vector3.Distance(path[current_planet_index].transform.position, gameObject.transform.position) < )
            transform.LookAt();
        }
    }
}
