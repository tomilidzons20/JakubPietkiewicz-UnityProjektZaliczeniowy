using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    public WeaponPoint weaponPoint;
    public Staff staff;
    public Animator staffAnimator;

    public PlayerWeaponStats weaponStats;

    private bool isShooting;

    private bool shootOnCooldown;
    private AudioManager audioManager;

    void Start()
    {
        audioManager = AudioManager.instance;
    }

    void Update()
    {
        if (GameState.GameIsPaused)
        {
            return;
        }

        if (isShooting && !staff.isSwinging)
        {
            ShootProjectile();
        }
    }

    void OnFire(InputValue inputValue)
    {
        if (GameState.GameIsPaused)
        {
            return;
        }

        isShooting = inputValue.isPressed;
    }

    void OnAltFire()
    {
        if (GameState.GameIsPaused)
        {
            return;
        }

        SwingStaff();
    }

    public void ShootProjectile()
    {
        if (shootOnCooldown)
        {
            return;
        }

        weaponStats.UpdateStats();
        GameObject projectile = Instantiate(weaponStats.projectilePrefab, staff.shootPoint.position, weaponPoint.transform.rotation);
        audioManager.Play("Shoot");
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.velocity = weaponStats.projectileSpeed * weaponPoint.transform.right;
        StartCoroutine(ShootInterval());
    }

    public void SwingStaff()
    {
        if (staff.isSwinging)
        {
            return;
        }

        staffAnimator.SetTrigger("Swing");
    }

    IEnumerator ShootInterval()
    {
        shootOnCooldown = true;
        yield return new WaitForSeconds(weaponStats.projectileInterval);
        shootOnCooldown = false;
    }
}
