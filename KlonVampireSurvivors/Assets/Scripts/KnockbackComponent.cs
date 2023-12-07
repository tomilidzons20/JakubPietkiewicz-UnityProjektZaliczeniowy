using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KnockbackComponent : MonoBehaviour
{
    private Rigidbody2D rb;
    public float knockbackDuration = 0.2f;
    public float defaultKnockbackForce = 5f;

    // Used mainly to stop and start enemy movement during knockback duration
    public UnityEvent OnStart;
    public UnityEvent OnEnd;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void ApplyKnockback(float knockbackForce, GameObject sender)
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
