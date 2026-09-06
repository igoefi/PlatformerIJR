using System;
using UnityEngine;

[RequireComponent(typeof(StatsHandler))]
public class Health : MonoBehaviour, IDamagable
{
    private StatsHandler _stats;

    public event Action DieEvent; 
    public event Action HealEvent;
    public event Action GetDamageEvent;
    
    private void Awake()
    {
        _stats = GetComponent<StatsHandler>();
    }

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
        
        HealEvent?.Invoke();
    }
}
