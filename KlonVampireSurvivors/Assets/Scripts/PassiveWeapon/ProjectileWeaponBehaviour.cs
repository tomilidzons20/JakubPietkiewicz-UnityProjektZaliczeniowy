using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class ProjectileWeaponBehaviour : MonoBehaviour
{
    public Vector3 projectileDirection;

    public float projectileDuration;
    public int projectileDamage;
    public float projectileKnockbackForce;
    public int projectilePierce;

    protected virtual void Start()
    {
        Destroy(gameObject, projectileDuration);
    }

    public virtual void ProjectileDirection(Vector3 direction)
    {
        projectileDirection = direction;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            HealthComponent health = collision.GetComponent<HealthComponent>();
            if (health)
            {
                health.GetHit(projectileDamage, projectileKnockbackForce, transform.root.gameObject);
            }
        }
    }

    protected virtual void PierceHandler()
    {
        projectilePierce -= 1;
        if (projectilePierce < 0)
        {
            Destroy(gameObject);
        }
    }
}
