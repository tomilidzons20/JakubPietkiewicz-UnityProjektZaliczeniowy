using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newWeaponStats", menuName = "Stats/WeaponScriptable", order = 1)]
public class WeaponScriptable : ScriptableObject
{
    [SerializeField]
    GameObject Projectile;
    public GameObject projectile { get => Projectile; private set => Projectile = value;}

    [SerializeField]
    float Speed;
    public float speed { get => Speed; private set => Speed = value; }

    [SerializeField]
    float Interval;
    public float interval { get => Interval; private set => Interval = value; }

    [SerializeField]
    float Duration;
    public float duration { get => Duration; private set => Duration = value; }

    [SerializeField]
    float KnockbackForce;
    public float knockbackForce { get => KnockbackForce; private set => KnockbackForce = value; }
    
    [SerializeField]
    int Damage;
    public int damage { get => Damage; private set => Damage = value; }

    [SerializeField]
    int Pierce;
    public int pierce { get => Pierce; private set => Pierce = value; }
}
