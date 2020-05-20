using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHealth : MonoBehaviour
{
    private float health;

    public void SetHealth(float temp_health)
    {
        health = temp_health;
    }

    public float GetHealth()
    {
        return health;
    }

    public void DecreaseHealth(float anAmount)
    {
        health -= anAmount;
    }
}
