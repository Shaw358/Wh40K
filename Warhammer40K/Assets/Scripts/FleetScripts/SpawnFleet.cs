using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFleet : MonoBehaviour
{
    private List<GameObject> fleet_pool = new List<GameObject>();
    private Transform fleet_pool_location;
    [SerializeField] private GameObject new_fleet;

    private void Awake()
    {
        GameObject temp_fleet_pool = GameObject.Find("fleet_pool");
        fleet_pool_location = temp_fleet_pool.transform;
        for (int i = 0; i < temp_fleet_pool.transform.childCount; i++)
        {
           fleet_pool.Add(temp_fleet_pool.transform.GetChild(i).gameObject.GetComponent<MovingFleet>().gameObject);
        }
    }

    public void Setup(GameObject prefab)
    {
        new_fleet = prefab;
    }

    public void MoveFleetOnMap(Planet target, int fleets_selected_count, Planet curr_planet, List<Fleet> fleets_to_move)
    {
        if (fleets_selected_count > 0)
        {
            curr_planet.GetInventory().RemoveItems(fleets_to_move);

            for (int i = 0; i < fleet_pool.Count; i++)
            {
                if (!fleet_pool[i].gameObject.activeSelf)
                {
                    fleet_pool[i].GetComponent<MovingFleet>().Activate(fleets_to_move, target, curr_planet);
                    break;
                }
                else
                {
                    GameObject spawned_fleet = Instantiate(new_fleet, fleet_pool_location.position, fleet_pool_location.rotation);
                    spawned_fleet.transform.parent = fleet_pool_location.transform;
                    fleet_pool.Add(spawned_fleet);
                }
            }
        }
    }
}
