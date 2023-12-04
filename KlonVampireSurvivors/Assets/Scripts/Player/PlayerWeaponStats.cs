using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponStats : MonoBehaviour
{
    [SerializeField]
    private WeaponScriptable data;

    public GameObject projectilePrefab;
    public float projectileInterval;
    public float projectileSpeed;
    public float projectileDuration;
    public float projectileKnockbackForce;
    public int projectileDamage;
    public int projectilePierce;

    void Awake()
    {
        projectilePrefab = data.projectile;
        projectileInterval = data.interval;
        projectileSpeed = data.speed;
        projectileDuration = data.duration;
        projectileKnockbackForce = data.knockbackForce;
        projectileDamage = data.damage;
        projectilePierce = data.pierce;
    }
}
