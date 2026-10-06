using System;
using System.Collections.Generic;
using UnityEngine;

public class VampirizmDamager : MonoBehaviour
{
    [SerializeField] private LayerMask _ignoreLayers;
    [SerializeField] private Vector2 _castOffset;

    public bool VampireAttack(float damage, float radius)
    {
        RaycastHit2D[] casts = Physics2D.CircleCastAll(new Vector2(transform.position.x, transform.position.y) + _castOffset,  
            radius, Vector2.zero, radius, ~_ignoreLayers);
        
        foreach (var cast in casts)
            if (cast.transform.gameObject.TryGetComponent(out IDamagable target))
            {
                target.TakeDamage(damage);
                return true;
            }
        
        return false;
    }
}
