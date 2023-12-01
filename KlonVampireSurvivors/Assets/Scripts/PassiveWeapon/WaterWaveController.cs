using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterWaveController : WeaponController
{
    // WaterWave shoots in direction of player movement
    protected override void Update()
    {
        base.Update();
    }

    protected override void Attack()
    {
        base.Attack();
        GameObject wave = Instantiate(projectile);
        Vector2 playerMovementDirection = playerMovement.lastMovementDirection;

        // Setup wave position to player and rotation to movement direction
        wave.transform.position = transform.position;
        wave.transform.right = playerMovementDirection;
        wave.GetComponent<WaterWaveBehaviour>().ProjectileDirection(playerMovementDirection);
    }
}
