using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private LayerMask _ignoreLayers;
    [SerializeField] private float _radius;

    private float _damage;
    
    public void SetDamage(float damage)
    {
        _damage = damage;
    }
    
    public void StopPlayerFollowing() =>
        transform.parent = transform.parent.parent;
    
    public void Attack()
    {
        RaycastHit2D[] targets = Physics2D.CircleCastAll(transform.position, _radius, Vector2.one, _radius, ~_ignoreLayers);

        foreach (var target in targets)
        {
            if(target.collider.TryGetComponent(out IDamagable damagable))
                damagable.TakeDamage(_damage);
        }
    }

    public void DestroyAfterAnimation() =>
        Destroy(gameObject);
}
