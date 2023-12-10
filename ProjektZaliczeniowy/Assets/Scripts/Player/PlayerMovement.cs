using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    public WeaponPoint weaponPoint;
    public PlayerStats stats;

    Vector2 cursorPosition;

    [HideInInspector]
    public Vector2 movementDirection;

    void Update()
    {
        // Add OnLook cause in new input system mouse position only updates on mouse movement and it bugs out cursor position
        OnLook();
        weaponPoint.cursorPosition = cursorPosition;
    }

    void FixedUpdate()
    {
        rb.velocity = movementDirection * stats.moveSpeed;
    }

    void OnMove(InputValue movementValue)
    {
        if (GameState.GameIsPaused)
        {
            // Prevent movement when button held down and then paused
            // Player used to move without input in last direction
            movementDirection = Vector2.zero;
            animator.SetBool("IsMoving", false);
            return;
        }

        movementDirection = movementValue.Get<Vector2>().normalized;
        animator.SetFloat("Horizontal", movementDirection.x);
        animator.SetFloat("Vertical", movementDirection.y);
        if (movementDirection.sqrMagnitude > 0)
        {
            animator.SetBool("IsMoving", true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }
    }

    void OnLook()
    {
        if (GameState.GameIsPaused)
        {
            return;
        }

        Vector3 mousePosition = Mouse.current.position.ReadValue();
        mousePosition.z = Camera.main.nearClipPlane;
        cursorPosition = Camera.main.ScreenToWorldPoint(mousePosition);
    }
}
