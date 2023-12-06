using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField]
    private EnemyScriptable data;

    public float health;
    public float moveSpeed;
    public float damage;

    void Awake()
    {
        health = data.maxHealth;
        moveSpeed = data.moveSpeed;
        damage = data.damage;
    }

    void Start()
    {
        GetComponent<HealthComponent>().HealthSetup(health);
    }
}
