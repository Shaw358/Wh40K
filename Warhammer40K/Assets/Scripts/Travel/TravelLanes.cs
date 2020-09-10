using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelLanes : MonoBehaviour
{
    /// <summary>
    /// Spawns Line renderers between planets
    /// </summary>
    List<LineRenderer> line_renderer = new List<LineRenderer>();
    private List<PlanetInventory> accessible_planets = new List<PlanetInventory>();

    List<GameObject> connected_planets = new List<GameObject>();
    [SerializeField] private Material[] line_materials;

    //gets planets within range, checks if they are already connected with them, if not they will spawn a lane otherwise it is ingored
    public void Setup()
    {
        int radius = 15;

        Collider[] planets_in_range = Physics.OverlapSphere(transform.position, radius, 1 << 8);

        for (int j = 0; j < planets_in_range.Length; j++)
        {
            accessible_planets.Add(planets_in_range[j].gameObject.GetComponent<PlanetInventory>());
        }

        for (int i = 0; i < planets_in_range.Length - 1; i++)
        {
            if (!connected_planets.Contains(planets_in_range[i].gameObject))
            {
                GameObject empty_gameobject = new GameObject();

                empty_gameobject.transform.parent = gameObject.transform;

                line_renderer.Add(empty_gameobject.AddComponent<LineRenderer>());

                line_renderer[i].startWidth = 0.2f;
                line_renderer[i].endWidth = 0.2f;

                Vector3 planet1 = transform.position;
                planet1.y -= 0.5f;
                line_renderer[i].SetPosition(0, planet1);

                Vector3 planet2 = accessible_planets[i].transform.position;
                planet2.y -= 0.5f;
                line_renderer[i].SetPosition(1, planet2);

                line_renderer[i].material = line_materials[0];

                accessible_planets[i].gameObject.transform.GetChild(0).GetComponent<TravelLanes>().SetConnectedPlanet(gameObject);
            }
        }
    }

    #region Getters/setters

    public void SetConnectedPlanet(GameObject planet)
    {
        connected_planets.Add(planet);
    }

    public List<PlanetInventory> GetAccessiblePlanets()
    {
        return accessible_planets;
    }

    public void AddLineRenderer(LineRenderer line_rend_to_add)
    {
        line_renderer.Add(line_rend_to_add);
    }

    #endregion

    public void SetLineMaterial(int index)
    {
        foreach (LineRenderer line in line_renderer)
        {
            line.material = line_materials[index];
        }
    }
}
