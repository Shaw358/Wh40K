using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHealth : MonoBehaviour
{
    private int health;

    public void SetHealth(int temp_health)
    {
        health = temp_health;
    }

    public float GetHealth()
    {
        return health;
    }

    public void DecreaseHealth(int anAmount)
    {
        health -= anAmount;
    }

    public void AddHealth(int anAmount)
    {
        health += anAmount;
    }
}
