using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healAmount;

    public void Collect()
    {
        PlayerStats stats = FindObjectOfType<PlayerStats>();
        stats.health.Heal(healAmount);
        Destroy(gameObject);
    }
}
