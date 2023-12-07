using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPoint : MonoBehaviour
{
    [HideInInspector]
    public Vector2 cursorPosition;

    void Update()
    {
        // When swinging rotate/scale staff sprite to correct orientation
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
}
