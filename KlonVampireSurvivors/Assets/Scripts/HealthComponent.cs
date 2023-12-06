using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthComponent : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    private bool isDead;
    private KnockbackComponent knockbackComponent;

    public float invincibilityDuration;
    private bool canGetHit;

    public UnityEvent OnHit;
    public UnityEvent OnDeath;
    private AudioManager audioManager;

    void Start()
    {
        knockbackComponent = GetComponent<KnockbackComponent>();
        canGetHit = true;
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void HealthSetup(float health)
    {
        maxHealth = health;
        currentHealth = health;
        isDead = false;
    }

    public void Heal(float heal)
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

    public void GetHit(float damage, float knockbackForce, GameObject sender)
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
            if (damage > 0)
            {
                audioManager.Play("Hit");
            }
        }
        else
        {
            audioManager.Play("Death");
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
