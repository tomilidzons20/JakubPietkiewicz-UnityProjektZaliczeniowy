using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    private PlayerScriptable data;
    public HealthComponent health;

    // Stats
    public float moveSpeed;
    public int maxHealth;
    public int healthRegen;
    public float projectileSpeed;
    public float projectileDamage;
    public float projectileDuration;

    [Space(10)]
    // Levels
    public int level = 1;
    public int experience = 0;
    public int experienceToLevel = 5;
    public int experienceIncrease = 10;

    private bool canHeal = true;

    void Awake()
    {
        moveSpeed = data.moveSpeed;
        maxHealth = data.maxHealth;
        healthRegen = data.healthRegen;
        projectileSpeed = data.projectileSpeed;
        projectileDamage = data.projectileDamage;
        projectileDuration = data.projectileDuration;
        health.HealthSetup(data.maxHealth);
    }

    void Update()
    {
        HealthRegen();
    }

    public void AddExp(int exp)
    {
        experience += exp;
        CheckLevelUp();
    }

    public void CheckLevelUp()
    {
        if (experience >= experienceToLevel) 
        {
            level += 1;
            experience -= experienceToLevel;
            experienceToLevel += experienceIncrease;
        }
    }

    public void HealthRegen()
    {
        if(healthRegen > 0 && canHeal)
        {
            health.Heal(1);
            StartCoroutine(HealInterval());
        }
    }

    private IEnumerator HealInterval()
    {
        canHeal = false;
        yield return new WaitForSeconds(healthRegen);
        canHeal = true;
    }
}
