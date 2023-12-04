using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickups : MonoBehaviour
{
    float pullSpeed = 15;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("ExpPickup") || collision.CompareTag("HpPickup"))
        {
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            Vector2 direction = (transform.position - rb.transform.position).normalized;
            rb.MovePosition(rb.position + direction * pullSpeed * Time.fixedDeltaTime);
        }
    }
}
