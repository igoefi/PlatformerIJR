using System;
using UnityEngine;

public class EnemyVisionCollider : MonoBehaviour
{
    public event Action<Collider2D> SeePlayer;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent(out PlayerStatsHandler _))
            SeePlayer.Invoke(other);
    }
}
