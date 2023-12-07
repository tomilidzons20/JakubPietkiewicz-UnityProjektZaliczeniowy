using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponStats : MonoBehaviour
{
    [SerializeField]
    private WeaponScriptable data;
    [SerializeField]
    private PlayerStats playerStats;

    public GameObject projectilePrefab;
    public float projectileInterval;
    public float projectileSpeed;
    public float projectileDuration;
    public float projectileDamage;
    public int projectilePierce;

    void Awake()
    {
        projectilePrefab = data.projectile;
        projectileInterval = data.interval;
        UpdateStats();
    }

    public void UpdateStats()
    {
        projectileSpeed = data.speed * (1 + playerStats.projectileSpeed/100);
        projectileDuration = data.duration * (1 + playerStats.projectileDuration/100);
        projectileDamage = data.damage * (1 + playerStats.projectileDamage/100);
        projectilePierce = data.pierce + playerStats.projectilePierce;
    }
}
