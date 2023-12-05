using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    private PlayerScriptable data;
    public HealthComponent health;
    public GameObject levelUpMenu;

    [Space(10)]
    // Stats
    public float moveSpeed;
    public float healthRegen;
    public float projectileSpeed;
    public int projectileDamage;
    public float projectileDuration;
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
        moveSpeed = data.moveSpeed;
        healthRegen = data.healthRegen;
        projectileSpeed = data.projectileSpeed;
        projectileDamage = data.projectileDamage;
        projectileDuration = data.projectileDuration;
        projectilePierce = data.projectilePierce;
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
            health.maxHealth = level + data.maxHealth;
            OpenLevelUpMenu();
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

    public void UpgradeStats(string stat)
    {
        switch (stat)
        {
            case "moveSpeed":
                moveSpeed *= 1.1f;
                break;
            case "healthRegen":
                healthRegen -= 0.1f;
                if (healthRegen < 1f)
                {
                    healthRegen = 1f;
                }
                break;
            case "projectileDamage":
                projectileDamage += 1;
                break;
            case "projectileSpeed":
                projectileSpeed += 25f;
                break;
            case "projectileDuration":
                projectileDuration += 25f;
                break;
            case "projectilePierce":
                projectilePierce += 1;
                break;
        }
        CloseLevelUpMenu();
    }

    public void OpenLevelUpMenu()
    {

        levelUpMenu.SetActive(true);
        Time.timeScale = 0;
        PauseMenu.GameIsPaused = true;
        PauseMenu.PlayerLevelUps = true;
    }

    public void CloseLevelUpMenu()
    {
        levelUpMenu.SetActive(false);
        Time.timeScale = 1;
        PauseMenu.GameIsPaused = false;
        PauseMenu.PlayerLevelUps = false;
    }
}
