using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHealth : ScriptableObject
{
    private int total_health;
    private int health;

    public void SetHealth(int temp_health)
    {
        total_health = health = temp_health;
    }

    public string GetHealth()
    {
        return total_health.ToString() + " / " + health.ToString();
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