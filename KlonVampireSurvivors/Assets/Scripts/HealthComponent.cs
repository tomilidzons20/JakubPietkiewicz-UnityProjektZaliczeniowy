using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthComponent : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    private bool isDead;
    private KnockbackComponent knockbackComponent;

    public float invincibilityDuration;
    private bool canGetHit;

    public UnityEvent OnHit;
    public UnityEvent OnDeath;

    void Start()
    {
        knockbackComponent = GetComponent<KnockbackComponent>();
        canGetHit = true;
    }

    public void HealthSetup(int health)
    {
        maxHealth = health;
        currentHealth = health;
        isDead = false;
    }

    public void Heal(int heal)
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += heal;
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }   
        }
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
        if (!canGetHit)
        {
            return;
        }

        if (invincibilityDuration > 0)
        {
            StartCoroutine(IFrames());
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

    private IEnumerator IFrames()
    {
        canGetHit = false;
        yield return new WaitForSeconds(invincibilityDuration);
        canGetHit = true;
    }
}
