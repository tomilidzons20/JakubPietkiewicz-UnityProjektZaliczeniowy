using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthComponent : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    private bool isDead;

    public float invincibilityDuration;
    private bool canGetHit = true;

    public UnityEvent OnHit;
    public UnityEvent OnDeath;
    private AudioManager audioManager;

    void Start()
    {
        audioManager = AudioManager.instance;
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

    public void GetHit(float damage)
    {
        if (isDead)
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
