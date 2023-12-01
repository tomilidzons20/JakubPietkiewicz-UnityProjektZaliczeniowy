using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 4f;

    public Rigidbody2D rb;
    public Animator animator;
    public WeaponPoint weaponPoint;

    Vector2 cursorPosition;

    public Vector2 movementDirection;
    [HideInInspector]
    public Vector2 lastMovementDirection;

    void Start()
    {
        lastMovementDirection = transform.right;    
    }

    void Update()
    {
        weaponPoint.cursorPosition = cursorPosition;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movementDirection * movementSpeed * Time.fixedDeltaTime);
    }

    void OnMove(InputValue movementValue)
    {
        movementDirection = movementValue.Get<Vector2>().normalized;
        animator.SetFloat("Horizontal", movementDirection.x);
        animator.SetFloat("Vertical", movementDirection.y);
        if (movementDirection.sqrMagnitude > 0)
        {
            lastMovementDirection = movementDirection;
            animator.SetBool("IsMoving", true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }
    }

    void OnLook()
    {
        Vector3 mousePosition = Mouse.current.position.ReadValue();
        mousePosition.z = Camera.main.nearClipPlane;
        cursorPosition = Camera.main.ScreenToWorldPoint(mousePosition);
    }
}
