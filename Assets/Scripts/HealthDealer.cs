using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDealer : MonoBehaviour
{
    [SerializeField] int Health_bonus = 10;

    public int GetHealth()
    {
        return Health_bonus;
    }

    public void Hitt()
    {
        Destroy(gameObject);
    }
}
