using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private PlayerWeaponStats stats;
    private int currentPierce;

    void Awake()
    {
        stats = FindObjectOfType<PlayerWeaponStats>();
        currentPierce = stats.projectilePierce;
        Destroy(gameObject, stats.projectileDuration);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            HealthComponent health = collision.GetComponent<HealthComponent>();
            if (health)
            {
                health.GetHit(stats.projectileDamage, 0, stats.gameObject);
            }
            PierceHandler();
        }
    }

    void PierceHandler()
    {
        currentPierce -= 1;
        if (currentPierce < 0)
        {
            Destroy(gameObject);
        }
    }
}
