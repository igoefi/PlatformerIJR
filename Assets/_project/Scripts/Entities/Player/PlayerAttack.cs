using System;
using UnityEngine;

[RequireComponent(typeof(PlayerStatsHandler))]
public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private LayerMask _ignoreLayers;
    [SerializeField] private Transform _attackPoint;

    private PlayerStatsHandler _stats;

    private void Awake()
    {
        _stats = GetComponent<PlayerStatsHandler>();
    }

    public void Attack()
    {
        RaycastHit2D[] targets = Physics2D.CircleCastAll(transform.position, _stats.AttackDistance,
            Vector2.one, _stats.AttackDistance, ~_ignoreLayers);

        foreach (var target in targets)
        {
            if(target.collider.TryGetComponent(out IDamagable damagable))
                damagable.TakeDamage(_stats.Damage);
        }
    }
}
