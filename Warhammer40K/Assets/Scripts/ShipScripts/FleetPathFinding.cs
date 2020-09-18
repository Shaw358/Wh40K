using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleetPathFinding
{
    public List<GameObject> FindPath(Planet first_planet, Planet target_planet)
    {
        List<GameObject> path = new List<GameObject>();
        Planet previous_planet = null;
        Planet curr_planet = first_planet;
        Planet lowest_distance_planet = null;
        float lowest_distance_value = 10000000;
        float reset_value = 10000000;

        if (first_planet.GetTravelLanes().GetAccessiblePlanets().Contains(target_planet))
        {
            List<Planet> planets = first_planet.GetTravelLanes().GetAccessiblePlanets();
            int goal = first_planet.GetTravelLanes().GetAccessiblePlanets().IndexOf(target_planet);
            Planet planet = planets[goal];
            path.Add(planet.gameObject);
        }
        else
        {
            foreach (Planet acc_planets in first_planet.GetTravelLanes().GetAccessiblePlanets())
            {
                float distance = Vector3.Distance(acc_planets.transform.position, target_planet.gameObject.transform.position);
                if (distance < lowest_distance_value)
                {
                    curr_planet = acc_planets;

                    lowest_distance_planet = acc_planets;
                    lowest_distance_value = distance;
                }
            }
            previous_planet = first_planet;
            path.Add(lowest_distance_planet.gameObject);
        }

        int crash_preventer = 0;
        lowest_distance_value = reset_value;

        while (true)
        {
            crash_preventer++;
            if (path[path.Count - 1] == target_planet.gameObject)
            {
                break;
            }

            if (curr_planet.GetTravelLanes().GetAccessiblePlanets().Count > 1)
            {
                if (curr_planet.GetTravelLanes().GetAccessiblePlanets().Contains(target_planet))
                {
                    List<Planet> planets = curr_planet.GetTravelLanes().GetAccessiblePlanets();
                    int goal = curr_planet.GetTravelLanes().GetAccessiblePlanets().IndexOf(target_planet);
                    Planet planet = planets[goal];
                    path.Add(planet.gameObject);
                }
                else
                {
                    Planet temp_curr_planet = curr_planet;
                    //previous_planet = curr_planet;
                    foreach (Planet acc_planets in curr_planet.GetTravelLanes().GetAccessiblePlanets())
                    {
                        float distance = Vector3.Distance(acc_planets.transform.position, target_planet.gameObject.transform.position);
                        if (distance < lowest_distance_value && previous_planet != acc_planets)
                        {
                            curr_planet = acc_planets;

                            lowest_distance_planet = acc_planets;
                            lowest_distance_value = distance;
                        }
                    }
                    previous_planet = temp_curr_planet;
                    lowest_distance_value = reset_value;
                    path.Add(lowest_distance_planet.gameObject);
                }
            }
            if (crash_preventer == 200)
            {
                /*foreach(GameObject planet in path)
                {
                    Debug.Log(planet.name);
                }*/
                Debug.LogWarning("Pathfinding Failed!");
                throw new System.Exception("Our navigator could not find a path! The fleet is lost!\nWe have tried plotting a course over 200 star systems... yet we have failed.\nMay the Emperor protect us all!");
            }
        }
        return path;
    }
}