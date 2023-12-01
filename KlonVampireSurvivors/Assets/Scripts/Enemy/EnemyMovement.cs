using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    public EnemyStats stats;

    private Transform player;

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
    }

    void FixedUpdate()
    {
        MoveTowardsPlayer();
    }

    void MoveTowardsPlayer()
    {
        Vector2 direction = (player.transform.position - transform.position).normalized;
        rb.MovePosition(rb.position + direction * stats.moveSpeed * Time.fixedDeltaTime);
    }
}
