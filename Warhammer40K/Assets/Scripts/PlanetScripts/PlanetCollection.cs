using UnityEngine;

public class PlanetCollection : MonoBehaviour
{
    [SerializeField] Planet[] all_planets;

    public void SearchPlanets()
    {
        GameObject[] planets = GameObject.FindGameObjectsWithTag("planet");
        for (int i = 0; i < planets.Length; i++)
        {
            all_planets[i] = planets[i].GetComponent<Planet>();
        }
    }

    public Planet[] GetAllPlanets()
    {
        return all_planets;
    }

    public Planet GetRandomPlanet()
    {
        int random = Random.Range(0, all_planets.Length);
        Debug.Log(random);
        return all_planets[random];
    }
}