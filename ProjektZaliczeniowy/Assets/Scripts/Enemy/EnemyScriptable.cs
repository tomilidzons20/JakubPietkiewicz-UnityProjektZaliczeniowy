using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newEnemyStats", menuName = "Stats/EnemyScriptable", order = 2)]
public class EnemyScriptable : ScriptableObject
{
    [SerializeField]
    float MaxHealth;
    public float maxHealth { get => MaxHealth; private set => MaxHealth = value; }

    [SerializeField]
    float MoveSpeed;
    public float moveSpeed { get => MoveSpeed; private set => MoveSpeed = value; }

    [SerializeField]
    float Damage;
    public float damage { get => Damage; private set => Damage = value; }
}