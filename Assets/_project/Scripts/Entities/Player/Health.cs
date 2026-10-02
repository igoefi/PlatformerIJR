using System;
using UnityEngine;

[RequireComponent(typeof(StatsHandler))]
public class Health : MonoBehaviour, IDamagable
{
    public float MaxHealthCount { get; private set; }
    public float HealthCount  { get; private set; }
    
    public event Action DieEvent; 
    public event Action HealEvent;
    public event Action GetDamageEvent;

    public void SetHealth(float maxHealth, float health)
    {
        MaxHealthCount = maxHealth;
        HealthCount = health;
    }

    public void TakeDamage(float damage)
    {
        HealthCount -= damage;
        
        if (HealthCount <= 0)
        {
            HealthCount = 0;
            DieEvent?.Invoke();
            return;
        }
        
        GetDamageEvent?.Invoke();
    }
    
    public void Heal(float healAmount)
    {
        HealthCount += healAmount;
        
        if (HealthCount >= MaxHealthCount)
            HealthCount = MaxHealthCount;
        
        HealEvent?.Invoke();
    }
}
