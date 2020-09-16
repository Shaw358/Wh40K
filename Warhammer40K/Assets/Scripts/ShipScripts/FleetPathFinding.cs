using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleetPathFinding
{
    public List<GameObject> FindPath(Planet first_planet, Planet target_planet)
    {
        List<GameObject> path = new List<GameObject>();
        Planet curr_planet = first_planet;
        Planet lowest_distance_planet = null;
        float lowest_distance_value = 10000000;

        foreach (Planet acc_planets in first_planet.GetTravelLanes().GetAccessiblePlanets())
        {
            if (acc_planets == target_planet.GetComponentInParent<Planet>())
            {
                path.Add(acc_planets.gameObject);
                break;
            }
            else
            {
                float distance = Vector3.Distance(acc_planets.transform.position, curr_planet.gameObject.transform.position);
                if (distance < lowest_distance_value)
                {
                    curr_planet = acc_planets.GetComponentInChildren<Planet>();

                    lowest_distance_planet = acc_planets;
                    lowest_distance_value = distance;
                }
            }
        }

        if (lowest_distance_planet != null)
        {
            path.Add(lowest_distance_planet.gameObject);
        }

        int crash_preventer = 0;

        while (true)
        {
            crash_preventer++;
            if (path[path.Count - 1] == target_planet.gameObject)
            {
                break;
            }

            if (curr_planet.GetTravelLanes().GetAccessiblePlanets().Count > 1)
            {
                if (curr_planet.GetTravelLanes().GetAccessiblePlanets().Contains(target_planet.GetComponentInParent<Planet>()))
                {
                    foreach (Planet acc_planets in curr_planet.GetTravelLanes().GetAccessiblePlanets())
                    {
                        if (acc_planets == target_planet)
                        {
                            path.Add(acc_planets.gameObject);
                        }
                    }
                    break;
                }
                else
                {
                    Debug.Log("");
                    foreach (Planet acc_planets in curr_planet.GetTravelLanes().GetAccessiblePlanets())
                    {
                        float distance = Vector3.Distance(acc_planets.transform.position, curr_planet.gameObject.transform.position);
                        if (distance < lowest_distance_value)
                        {
                            curr_planet = acc_planets.GetComponent<Planet>();

                            lowest_distance_planet = acc_planets;
                            lowest_distance_value = distance;
                        }
                    }
                    path.Add(lowest_distance_planet.gameObject);
                }
            }
            if (crash_preventer == 200)
            {
                Debug.Log("Pathfinding Failed!");
                throw new System.Exception("Our navigator could not find a path! The fleet is lost!\nWe have tried plotting a course over 200 star systems... yet we have failed.\nMay the Emperor protect us all!");
            }
        }
        return path;
    }
}