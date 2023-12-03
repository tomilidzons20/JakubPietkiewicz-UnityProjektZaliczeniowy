using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField]
    private WeaponScriptable stats;

    public GameObject projectile;
    public float speed;
    public float interval;
    public float duration;
    public float knockbackForce;
    public int damage;
    public int pierce;

    public PlayerMovement playerMovement;

    private bool canAttack = true;

    void Awake()
    {
        projectile = stats.projectile;
        speed = stats.speed;
        interval = stats.interval;
        duration = stats.duration;
        knockbackForce = stats.knockbackForce;
        damage = stats.damage;
        pierce = stats.pierce;
    }

    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }


    // Update is called once per frame
    protected virtual void Update()
    {
        if (canAttack)
        {
            Attack();
        }
    }

    protected virtual void Attack()
    {
        if (!canAttack)
        {
            return;
        }
        StartCoroutine(AttackInterval());
    }

    IEnumerator AttackInterval()
    {
        canAttack = false;
        yield return new WaitForSeconds(interval);
        canAttack = true;
    }
}
