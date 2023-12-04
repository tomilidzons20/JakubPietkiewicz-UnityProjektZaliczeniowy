using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField]
    private EnemyScriptable data;

    public int health;
    public float moveSpeed;
    public int damage;

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
