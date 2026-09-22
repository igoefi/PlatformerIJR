using System;
using UnityEngine;

[RequireComponent(typeof(StatsHandler))]
public class Health : MonoBehaviour, IDamagable
{
    private float _maxHealth;
    private float _health;
    
    public event Action DieEvent; 
    public event Action HealEvent;
    public event Action GetDamageEvent;

    public void SetHealth(float maxHealth, float health)
    {
        _maxHealth = maxHealth;
        _health = health;
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        
        if (_health <= 0)
        {
            _health = 0;
            DieEvent?.Invoke();
            return;
        }
        
        GetDamageEvent?.Invoke();
    }
    
    public void Heal(float healAmount)
    {
        _health += healAmount;
        
        if (_health >= _maxHealth)
            _health = _maxHealth;
        
        HealEvent?.Invoke();
    }
}
