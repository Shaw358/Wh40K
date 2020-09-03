using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelLanes : MonoBehaviour
{
    List<LineRenderer> line_renderer = new List<LineRenderer>();
    private List<GameObject> accessible_planets = new List<GameObject>();

    [SerializeField] private Color line_color;

    private void Start()
    {
        Setup();
    }

    public void Setup()
    {
        int radius = 15;
        Collider[] planets_in_range = Physics.OverlapSphere(transform.position, radius, 1 << 8);

        for(int i = 0; i < planets_in_range.Length - 1; i++)
        {
            if(planets_in_range[i].gameObject != gameObject)
            accessible_planets.Add(planets_in_range[i].gameObject);
            GameObject empty_gameobject = new GameObject();

            empty_gameobject.transform.parent = gameObject.transform;
            
            line_renderer.Add(empty_gameobject.AddComponent<LineRenderer>());

            line_renderer[i].startWidth = 0.2f;
            line_renderer[i].endWidth = 0.2f;
            line_renderer[i].startColor = line_color;
            line_renderer[i].endColor = line_color;

            Vector3 planet1 = transform.position;
            planet1.y -= 1;
            line_renderer[i].SetPosition(0, planet1);

            Vector3 planet2 = accessible_planets[i].transform.position;
            planet2.y -= 1;
            line_renderer[i].SetPosition(1, planet2);
        }
    }


    private void OnDrawGizmos()
    {
        //int radius = 15;
        //Gizmos.DrawWireSphere(transform.position, radius);
    }
    
}
