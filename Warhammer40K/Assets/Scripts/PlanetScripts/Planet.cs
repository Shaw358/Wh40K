using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Planet : MonoBehaviour
{
    protected int max_fleet_count;

    [SerializeField] protected string planet_name;

    protected PlanetFleetMenu pfm;
    protected List<Fleet> fleets = new List<Fleet>(); //fleets present in system

    private void OnMouseDown()
    {
        //TODO: Find alternative for getcomponent
        pfm.Activate(this.gameObject.GetComponent<PlanetInventory>());
    }
}
