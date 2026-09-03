using System;
using UnityEngine;

[RequireComponent(typeof(StatsHandler))]
public class HealGrabber : MonoBehaviour
{
    private StatsHandler _stats;

    private void Awake()
    {
        _stats = GetComponent<StatsHandler>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Heal heal) == false)
            return;
        
        _stats.Heal(heal.GetAndDestroy());
    }
}
