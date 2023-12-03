using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : MonoBehaviour
{
    public int staffDamage = 0;
    public float staffKnockbackForce = 6f;
    public float swingDelay = 4f;

    [HideInInspector]
    public bool isSwinging;

    public Transform shootPoint;
    public Collider2D staffHitbox;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            HealthComponent health = collision.GetComponent<HealthComponent>();
            if (health)
            {
                health.GetHit(staffDamage, staffKnockbackForce, transform.root.gameObject);
            }
        }
    }
}
