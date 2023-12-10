using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : MonoBehaviour
{
    public float knockbackForce = 15f;

    [HideInInspector]
    public bool isSwinging;

    public Transform shootPoint;
    private AudioManager audioManager;

    void Start()
    {
        audioManager = AudioManager.instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            KnockbackComponent knockback = collision.GetComponent<KnockbackComponent>();
            if (knockback)
            {
                audioManager.Play("Bonk");
                knockback.ApplyKnockback(knockbackForce, transform.root.gameObject);
            }
        }
    }
}
