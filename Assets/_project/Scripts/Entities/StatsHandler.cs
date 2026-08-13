using System;
using UnityEngine;

public class StatsHandler : MonoBehaviour, IDamagable
{
    public event Action DieEvent; 
    public event Action HealEvent;
    public event Action GetDamageEvent;
    
    [SerializeField] private StatsConfig _stats;
    
    public float MaxHealth { get { return _stats.MaxHealth; } }
    public float Health  { get { return _stats.Health; } private set { _stats.Health = value; } }
    public float Speed  { get { return _stats.Speed; } }
    public float Damage { get { return _stats.AttackDamage; }}
    public float AttackCooldown { get { return _stats.AttackCooldown; } }
    public float JumpForce { get { return _stats.JumpForce; } }
    public float FallGravityScale { get { return _stats.FallGravityScale; } }
    public float NormalGravityScale { get { return _stats.NormalGravityScale; } }
    
    public void TakeDamage(float damage)
    {
        _stats.Health -= damage;
        
        if (_stats.Health <= 0)
        {
            _stats.Health = 0;
            DieEvent?.Invoke();
            return;
        }
        
        GetDamageEvent?.Invoke();
    }
    
    public void Heal(float healAmount)
    {
        _stats.Health += healAmount;
        
        if (_stats.Health <= 0)
        {
            _stats.Health = 0;
        }
    }
}
