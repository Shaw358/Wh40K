using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFleet : MonoBehaviour
{
    private List<Fleet> fleets_to_transfer = new List<Fleet>();
    private List<GameObject> path = new List<GameObject>();
    private TravelLanes target_planet;

    private float distance_threshold = 0.5f;

    private int current_planet_index = 0;
    private int minimum_connection_lanes = 1;

    private Vector3 pool_position;

    private enum STATES
    {
        ACTIVE,
        NOT_ACTIVE,
        NONE
    }

    private STATES state = STATES.NOT_ACTIVE;

    private void Awake()
    {
        pool_position = GetComponentInParent<Transform>().position;
        gameObject.SetActive(false);
    }

    public void ClearFleets()
    {
        fleets_to_transfer.Clear();
    }

    public void Activate(List<Fleet> fleets, TravelLanes target, TravelLanes spawn_planet)
    {
        target_planet = target;
        transform.position = spawn_planet.transform.position;
        fleets_to_transfer.AddRange(fleets);
        SearchFastestPath(spawn_planet);
    }

    private void SearchFastestPath(TravelLanes first_planet)
    {
        TravelLanes curr_planet = first_planet;
        PlanetInventory lowest_distance_planet = null;
        float lowest_distance_value = 0;

        foreach (PlanetInventory acc_planets in first_planet.GetAccessiblePlanets())
        {
            float distance = Vector3.Distance(acc_planets.transform.position, curr_planet.gameObject.transform.position);
            if (distance != 0)
            {
                if (distance < lowest_distance_value)
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
            if (curr_planet.GetAccessiblePlanets().Count > minimum_connection_lanes)
            {
                foreach (PlanetInventory acc_planets in first_planet.GetAccessiblePlanets())
                {
                    float distance = Vector3.Distance(acc_planets.transform.position, curr_planet.gameObject.transform.position);
                    if (distance != 0)
                    {
                        if (distance < lowest_distance_value)
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
            }
            if (path[path.Count] == target_planet)
            {
                break;
            }
        }
        state = STATES.ACTIVE;
    }

    private void Update()
    {
        if (state == STATES.ACTIVE)
        {
            if (Vector3.Distance(path[current_planet_index].transform.position, gameObject.transform.position) < distance_threshold)
            {
                if (path.Count == current_planet_index)
                {
                    Arrived();
                }
                else
                {
                    current_planet_index++;
                }
            }
            transform.LookAt(path[current_planet_index].gameObject.transform);
        }
    }

    private void Arrived()
    {
        state = STATES.NOT_ACTIVE;
        //do animation or something?
        path[path.Count].GetComponent<PlanetInventory>().AddFleets(fleets_to_transfer);

        ClearFleets();

        gameObject.SetActive(false);
        //gameObject.transform.position = 
    }
}
