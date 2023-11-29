using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class KnockbackComponent : MonoBehaviour
{
    private Rigidbody2D rb;
    public float knockbackDuration = 0.2f;
    public float knockbackForce = 10f;

    public UnityEvent OnStart, OnEnd;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void ApplyKnockback(GameObject sender)
    {
        StopAllCoroutines();
        OnStart?.Invoke();
        Vector2 knockbackDirection = (transform.position - sender.transform.position).normalized;
        rb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
        StartCoroutine(StopKnockback());
    }

    private IEnumerator StopKnockback()
    {
        yield return new WaitForSeconds(knockbackDuration);
        rb.velocity = Vector3.zero;
        OnEnd?.Invoke();
    }

}
