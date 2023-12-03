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
}
