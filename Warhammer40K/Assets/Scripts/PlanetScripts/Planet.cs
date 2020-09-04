using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    protected int max_fleet_count;

    [SerializeField] protected string planet_name;

    protected PlanetFleetMenu pfm;
    protected List<Fleet> fleets = new List<Fleet>(); //fleets present in system

    public void RemoveFleets(int first_fleet, int last_fleet = 0)
    {
        if(last_fleet != 0)
        {
            fleets.RemoveRange(first_fleet, last_fleet);
        }
        else
        {
            fleets.RemoveAt(first_fleet);
        }
    }

    private void OnMouseOver()
    {
        //TODO: Find alternative for getcomponent
        if (Input.GetMouseButtonDown(0))
        {
            pfm.Activate(gameObject.GetComponent<PlanetInventory>());
        }
        if(Input.GetMouseButtonDown(1))
        {
            pfm.MoveFleetOnMap();
        }
    }
}
