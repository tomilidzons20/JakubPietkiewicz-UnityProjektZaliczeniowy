using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class WaterWaveBehaviour : ProjectileWeaponBehaviour
{
    private WaterWaveController controller;
    private Rigidbody2D rb;

    void Awake()
    {
        controller = FindObjectOfType<WaterWaveController>();
        projectileDuration = controller.duration;
        projectileDamage = controller.damage;
        projectileKnockbackForce = controller.knockbackForce;
        projectilePierce = controller.pierce;
    }

    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.velocity = controller.speed * projectileDirection;
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        PierceHandler();
    }

}
