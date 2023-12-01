using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public EnemyScriptable data;

    public int maxHealth;
    public float moveSpeed;
    public int damage;

    void Awake()
    {
        maxHealth = data.maxHealth;
        moveSpeed = data.moveSpeed;
        damage = data.damage;
    }

    void Start()
    {
        GetComponent<HealthComponent>().HealthSetup(maxHealth);
    }
}
