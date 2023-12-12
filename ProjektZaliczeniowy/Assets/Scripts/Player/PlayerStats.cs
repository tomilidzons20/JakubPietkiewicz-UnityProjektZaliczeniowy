using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    private PlayerScriptable data;
    public HealthComponent health;
    public LevelUpMenu levelUpMenu;
    public HealthBar healthBar;
    public ExperienceBar experienceBar;

    [Space(10)]
    // Stats
    public float moveSpeed;
    public float healthRegen;
    public float projectileSpeed;
    public float projectileDamage;
    public int projectilePierce;

    [Space(10)]
    // Levels
    public int level = 1;
    public int experience = 0;
    public int experienceToLevel = 5;
    public int experienceIncrease = 10;

    private bool canHeal = true;


    void Awake()
    {
        // Init stats
        moveSpeed = data.moveSpeed;
        healthRegen = data.healthRegen;
        projectileSpeed = data.projectileSpeed;
        projectileDamage = data.projectileDamage;
        projectilePierce = data.projectilePierce;

        // Init health component and healthbar
        health.HealthSetup(data.maxHealth);
        healthBar.SetHealth(data.maxHealth);
        healthBar.SetMaxHealth(data.maxHealth);

        // Init experiencebar
        experienceBar.SetExperience(experience);
        experienceBar.SetMaxExperience(experienceToLevel);
    }

    void Update()
    {
        HealthRegen();
    }

    public void AddExp(int exp)
    {
        experience += exp;
        CheckLevelUp();
        experienceBar.SetExperience(experience);
    }

    public void CheckLevelUp()
    {
        if (experience >= experienceToLevel) 
        {
            // Update level, exp, maxexp and experiencebar
            level++;
            // Save excess exp to next level
            experience -= experienceToLevel;
            experienceToLevel += experienceIncrease;
            experienceBar.SetExperience(experience);
            experienceBar.SetMaxExperience(experienceToLevel);

            // Update hp and healthbar max value
            float currentMaxHealth = level + data.maxHealth;
            health.maxHealth = currentMaxHealth;
            healthBar.SetMaxHealth(currentMaxHealth);

            levelUpMenu.OpenLevelUpMenu();
        }
    }
 
    public void HealthRegen()
    {
        if(healthRegen > 0 && canHeal)
        {
            health.Heal(1);
            StartCoroutine(HealInterval());
            healthBar.SetHealth(health.currentHealth);
        }
    }

    private IEnumerator HealInterval()
    {
        canHeal = false;
        yield return new WaitForSeconds(healthRegen);
        canHeal = true;
    }

    public void OnDamageTaken()
    {
        healthBar.SetHealth(health.currentHealth);
    }

    public void UpgradeStats(string stat)
    {
        switch (stat)
        {
            case "moveSpeed":
                moveSpeed *= 1.25f;
                break;
            case "healthRegen":
                healthRegen -= 0.1f;
                if (healthRegen < 1f)
                {
                    healthRegen = 1f;
                }
                break;
            case "projectileDamage":
                projectileDamage += 50f;
                break;
            case "projectileSpeed":
                projectileSpeed += 25f;
                break;
            case "projectilePierce":
                projectilePierce++;
                break;
        }

        levelUpMenu.CloseLevelUpMenu();
    }
}
