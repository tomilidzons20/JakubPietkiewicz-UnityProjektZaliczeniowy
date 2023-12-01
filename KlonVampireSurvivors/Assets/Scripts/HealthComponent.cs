using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthComponent : MonoBehaviour
{
    [SerializeField]
    private int maxHealth;
    [SerializeField]
    private int currentHealth;
    private bool isDead;
    private KnockbackComponent knockbackComponent;

    public UnityEvent OnHit;
    public UnityEvent OnDeath;

    void Start()
    {
        knockbackComponent = GetComponent<KnockbackComponent>();
    }

    public void HealthSetup(int health)
    {
        maxHealth = health;
        currentHealth = health;
        isDead = false;
    }

    public void GetHit(int damage, float knockbackForce, GameObject sender)
    {
        if (isDead)
        {
            return;
        }
        if (sender.layer == gameObject.layer)
        {
            return;
        }


        currentHealth -= damage;

        if (knockbackComponent)
        {
            knockbackComponent.ApplyKnockback(sender, knockbackForce);
        }

        if (currentHealth > 0) 
        {
            OnHit?.Invoke();
        }
        else
        {
            OnDeath?.Invoke();
            isDead = true;
            Destroy(gameObject);
        }
    }
}
