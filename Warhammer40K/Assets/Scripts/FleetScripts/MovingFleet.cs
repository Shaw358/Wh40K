using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFleet : MonoBehaviour
{
    GameSpeed gamespd;
    private List<Fleet> fleets_to_transfer = new List<Fleet>();
    private List<GameObject> path = new List<GameObject>();
    private Planet target_planet;

    private float distance_threshold = 0.5f;

    private int current_planet_index = 0;

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
        gamespd = GetComponent<GameSpeed>();
        pool_position = GetComponentInParent<Transform>().position;
        gameObject.SetActive(false);
    }

    public void Activate(List<Fleet> fleets, Planet target, Planet spawn_planet)
    {
        /*fleet_pool[i].*/gameObject.SetActive(true);
        FleetPathFinding pathfind = new FleetPathFinding();
        target_planet = target;
        transform.position = spawn_planet.transform.position;
        fleets_to_transfer.AddRange(fleets);
        path = pathfind.FindPath(spawn_planet, target);
        state = STATES.ACTIVE;
    }

    private void Update()
    {
        fleet_speed = gamespd.GetGameSpeed();
        //print(path.Count);
        if (state == STATES.ACTIVE)
        {
            Debug.Log("move");
            transform.LookAt(path[current_planet_index].gameObject.transform);
            transform.position += transform.forward * Time.deltaTime * fleet_speed;
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
        }
    }

    private void Arrived()
    {
        state = STATES.NOT_ACTIVE;
        //do animation or something?
        path[path.Count - 1].GetComponent<Planet>().GetInventory().AddItems(fleets_to_transfer);

        ResetObject();
    }
    public void ResetObject()
    {
        current_planet_index = 0;
        fleets_to_transfer.Clear();
        path.Clear();
        gameObject.SetActive(false);
        gameObject.transform.position = pool_position;
    }
}