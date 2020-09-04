using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFleet : MonoBehaviour
{
    private List<Fleet> fleet_to_transfer = new List<Fleet>();
    private PlanetInventory target_planet;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public void SetFleetsToTransfer(List<Fleet> fleets, PlanetInventory new_target)
    {
        target_planet = new_target;
        fleet_to_transfer.AddRange(fleets);
    }

    public void ClearFleets()
    {
        fleet_to_transfer.Clear();
    }

    private void Update()
    {
        if(gameObject.activeSelf)
        {
            transform.LookAt(target_planet.gameObject.transform);
        }
    }
}
