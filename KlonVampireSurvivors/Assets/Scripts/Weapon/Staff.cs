using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : MonoBehaviour
{
    public int staffDamage = 0;

    public Collider2D staffHitbox;

    void Start()
    {
        staffHitbox = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        HealthComponent health = collision.GetComponent<HealthComponent>();
        if (health)
        {
            health.GetHit(staffDamage, transform.root.gameObject);
        }
    }
}
