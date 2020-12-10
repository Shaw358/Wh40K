using System.Collections.Generic;
using UnityEngine;

public class PlanetNames : MonoBehaviour
{
    [SerializeField] List<string> planet_names = new List<string>();
    int rand;

    private void Start()
    {
        for (int i = 0; i < 60; i++)
        {
            planet_names.Add(i.ToString());
        }

        for (int i = 0; i < 60; i++)
        {
            try
            {
                transform.GetChild(i).GetChild(1).GetComponent<Planet>().SetPlanetName(GetRandPlanetName());
                RemoveName();
            }
            catch
            {
                //poep werk ?
            }
        }
        Destroy(this);
    }

    public string GetRandPlanetName()
    {
        rand = Random.Range(0, planet_names.Count - 1);
        return planet_names[rand];
    }

    public void RemoveName()
    {
        planet_names.RemoveAt(rand);
    }
}