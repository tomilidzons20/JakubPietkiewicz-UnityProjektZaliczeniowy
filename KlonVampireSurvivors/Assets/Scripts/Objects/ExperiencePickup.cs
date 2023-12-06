using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperiencePickup : MonoBehaviour
{
    public int experienceAmount;

    public void Collect()
    {
        PlayerStats stats = FindObjectOfType<PlayerStats>();
        stats.AddExp(experienceAmount);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Collect();
            FindObjectOfType<AudioManager>().Play("Pickup");
            Destroy(gameObject);
        }
    }
}
