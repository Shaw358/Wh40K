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

    private float fleet_speed = 10;

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

    public void Activate(List<Fleet> fleets, TravelLanes target, Planet spawn_planet)
    {
        target_planet = target;
        transform.position = spawn_planet.transform.position;
        fleets_to_transfer.AddRange(fleets);
        SearchFastestPath(spawn_planet);
    }

    private void SearchFastestPath(Planet first_planet)
    {
        Planet curr_planet = first_planet;
        Planet lowest_distance_planet = null;
        float lowest_distance_value = 10000000;

        foreach (Planet acc_planets in first_planet.GetTravelLanes().GetAccessiblePlanets())
        {
            float distance = Vector3.Distance(acc_planets.transform.position, curr_planet.gameObject.transform.position);
            if (distance < lowest_distance_value)
            {
                curr_planet = acc_planets.GetComponentInChildren<Planet>();

                lowest_distance_planet = acc_planets;
                lowest_distance_value = distance;
            }
        }

        path.Add(lowest_distance_planet.gameObject);

        int i = 0;

        while (true)
        {
            i++;
            if (path[path.Count - 1] == target_planet.gameObject)
            {
                break;
            }

            print(curr_planet.GetTravelLanes().GetAccessiblePlanets().Count);

            if (curr_planet.GetTravelLanes().GetAccessiblePlanets().Count > 1)
            {
                if (curr_planet.GetTravelLanes().GetAccessiblePlanets().Contains(target_planet.GetComponentInParent<Planet>()))
                {
                    print("Step 1");
                    foreach(Planet acc_planets in curr_planet.GetTravelLanes().GetAccessiblePlanets())
                    {
                        if(acc_planets.GetComponentInChildren<TravelLanes>() == target_planet)
                        {
                            print("Step 2");
                            path.Add(acc_planets.gameObject);
                        }
                    }
                    break;
                }
                else
                {
                    //print("step 1");
                    foreach (Planet acc_planets in curr_planet.GetTravelLanes().GetAccessiblePlanets())
                    {
                        //print("step 2");

                        float distance = Vector3.Distance(acc_planets.transform.position, curr_planet.gameObject.transform.position);
                        if (distance != 0)
                        {
                            print("step 3");
                            if (distance < lowest_distance_value)
                            {
                                print("step 4");
                                curr_planet = acc_planets.GetComponent<Planet>();

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
            }
            //Debug.Log("Planets to travel: " + i);
            if (i == 20)
            {
                Debug.Log("Pathfinding Failed!");
                break;
            }
        }
        state = STATES.ACTIVE;
    }

    private void Update()
    {
        //print("Pathfinding succeeded");
        //print(path.Count);
        if (state == STATES.ACTIVE)
        {
            if (Vector3.Distance(path[current_planet_index].transform.position, gameObject.transform.position) < distance_threshold)
            {
                if (path.Count - 1 == current_planet_index)
                {
                    Arrived();
                }
                else
                {
                    current_planet_index++;
                }
            }
            transform.LookAt(path[current_planet_index].gameObject.transform);
            transform.position += transform.forward * Time.deltaTime * fleet_speed;
        }
    }

    private void Arrived()
    {
        state = STATES.NOT_ACTIVE;
        //do animation or something?
        path[path.Count -1].GetComponent<Planet>().GetInventory().AddItems(fleets_to_transfer);

        ClearFleets();

        gameObject.SetActive(false);
        //gameObject.transform.position = 
    }
}
