using System;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class HealGrabber : MonoBehaviour
{
    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Heal heal) == false)
            return;
        
        _health.Heal(heal.GetAndDestroy());
    }
}
