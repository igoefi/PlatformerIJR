using System;
using UnityEngine;

[RequireComponent(typeof(StatsHandler))]
public class Health : MonoBehaviour, IDamagable
{
    public float MaxCount { get; private set; }
    public float Count  { get; private set; }
    
    public event Action DieEvent; 
    public event Action HealEvent;
    public event Action GetDamageEvent;

    public void SetHealth(float maxHealth, float health)
    {
        MaxCount = maxHealth;
        Count = health;
    }

    public void TakeDamage(float damage)
    {
        Count -= damage;
        
        if (Count <= 0)
        {
            Count = 0;
            DieEvent?.Invoke();
            return;
        }
        
        GetDamageEvent?.Invoke();
    }

    public void TakeDamage(float damage, out float damageTaken)
    {
        if (Count - damage <= 0)
        {
            damageTaken = Count;
            Count = 0;
            DieEvent?.Invoke();
            return;
        }

        Count -= damage;
        damageTaken = damage;
        GetDamageEvent?.Invoke();
    }
    
    public void Heal(float healAmount)
    {
        if (healAmount <= 0)
            return;
        
        Count += healAmount;
        
        if (Count >= MaxCount)
            Count = MaxCount;
        
        HealEvent?.Invoke();
    }
}
