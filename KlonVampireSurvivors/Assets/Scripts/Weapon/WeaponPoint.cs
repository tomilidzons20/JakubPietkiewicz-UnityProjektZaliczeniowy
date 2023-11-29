using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPoint : MonoBehaviour
{
    public Vector2 cursorPosition;

    public Animator animator;

    public float swingDelay = 0.2f;
    public float shootInterval = 0.5f;
    private bool isSwinging;
    private bool isShooting;

    void Update()
    {
        Vector2 cursorDirection = (cursorPosition - (Vector2)transform.position).normalized;
        transform.right = cursorDirection;
        Vector2 scale = transform.localScale;
        if (cursorDirection.x > 0)
        {
            scale.y = 1;
        }
        else if (cursorDirection.x < 0)
        {
            scale.y = -1;
        }
        transform.localScale = scale;
    }

    IEnumerator SwingDelay()
    {
        yield return new WaitForSeconds(swingDelay);
        isSwinging = false;
    }
    
    IEnumerator ShootInterval()
    {
        yield return new WaitForSeconds(shootInterval);
        isShooting = false;
    }

    public void SwingStaff()
    {
        if (isSwinging)
        {
            return;
        }
        animator.SetTrigger("Swing");
        isSwinging = true;
        StartCoroutine(SwingDelay());
    }

    public void ShootStaff()
    {
        if (isShooting)
        {
            return;
        }
        animator.SetTrigger("Shoot");
        isShooting = true;
        StartCoroutine(ShootInterval());
    }



}
