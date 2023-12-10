using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerStats", menuName = "Stats/PlayerScriptable", order = 1)]
public class PlayerScriptable : ScriptableObject
{
    [SerializeField]
    float MoveSpeed;
    public float moveSpeed { get => MoveSpeed; private set => MoveSpeed = value; }

    [SerializeField]
    float MaxHealth;
    public float maxHealth { get => MaxHealth; private set => MaxHealth = value; }

    // 1HP per x seconds
    [SerializeField]
    float HealthRegen;
    public float healthRegen { get => HealthRegen; private set => HealthRegen = value; }

    // % bonus speed
    [SerializeField]
    float ProjectileSpeed;
    public float projectileSpeed { get => ProjectileSpeed; private set => ProjectileSpeed = value; }

    // % bonus damage
    [SerializeField]
    float ProjectileDamage;
    public float projectileDamage { get => ProjectileDamage; private set => ProjectileDamage = value; }

    // + bonus pierce
    [SerializeField]
    int ProjectilePierce;
    public int projectilePierce { get => ProjectilePierce; private set => ProjectilePierce = value; }
}
