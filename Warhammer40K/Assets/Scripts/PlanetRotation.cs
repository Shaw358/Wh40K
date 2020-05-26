using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotation : MonoBehaviour
{
    private float rotation_speed;

    private void Awake()
    {
        rotation_speed = 0.1f;    
    }

    void Update()
    {
        transform.Rotate(0, rotation_speed, 0);
    }
}
