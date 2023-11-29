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

    public UnityEvent<GameObject> OnHit, OnDeath;

    public void HealthSetup(int health)
    {
        maxHealth = health;
        currentHealth = health;
        isDead = false;
    }

    public void GetHit(int damage, GameObject sender)
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

        if (currentHealth > 0) 
        {
            OnHit?.Invoke(sender);
        }
        else
        {
            OnDeath?.Invoke(sender);
            isDead = true;
            Destroy(gameObject);
        }
    }

}
