using System;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class StatsHandler : MonoBehaviour
{
    [SerializeField] private StatsData _stats;
    
    public float MaxHealth { get { return _stats.MaxHealth; } }
    public float Health  { get { return _stats.Health; }  set { _stats.Health = value; } }
    public float Speed  { get { return _stats.Speed; } }
    public float Damage { get { return _stats.AttackDamage; }}
    public float AttackCooldown { get { return _stats.AttackCooldown; } }
    public float JumpForce { get { return _stats.JumpForce; } }
    public float FallGravityScale { get { return _stats.FallGravityScale; } }
    public float NormalGravityScale { get { return _stats.NormalGravityScale; } }
    public float AttackDistance { get { return _stats.AttackDistanse; } }

    private void Awake()
    {
        Health health = GetComponent<Health>();
        health.SetHealth(_stats.MaxHealth, _stats.Health);
    }
}
