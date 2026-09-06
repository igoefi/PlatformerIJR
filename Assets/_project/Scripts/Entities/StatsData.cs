using System;
using UnityEngine;

[Serializable]
public class StatsData
{
    [Header("Movement")]
    public float Speed;
    public float JumpForce;
    public float FallGravityScale;
    public float NormalGravityScale;
    
    [Header("Battle")]
    public float MaxHealth;
    public float Health;
    public float AttackDamage;
    public float AttackCooldown;
    public float AttackDistanse;
}
