using System;
using UnityEngine;

[RequireComponent(typeof(EnemyVision),
    typeof(EnemyMovement),
    typeof(EnemyAnimator))]
public class WizardEnemy : Enemy
{
    private EnemyMovement  _movement;
    private EnemyVision _vision;
    private EnemyAnimator _anim;
    private WizardEnemyAttack _attack;
    private bool _isSeePlayer;
    
    private void Awake()
    {
        StatsHandler = GetComponent<StatsHandler>();
        _vision = GetComponent<EnemyVision>();
        _movement = GetComponent<EnemyMovement>();
        _anim = GetComponent<EnemyAnimator>();
        _attack = GetComponent<WizardEnemyAttack>();
        _attack.SetDamage(StatsHandler.Damage);
    }

    private void OnEnable()
    {
        _movement.MovingEvent += StartMoving;
        _movement.StopEvent += StopMoving;
        _vision.SeePlayerEvent += SeePLayer;
    }

    private void OnDisable()
    {
        _movement.MovingEvent -= StartMoving;
        _movement.StopEvent -= StopMoving;
        _vision.SeePlayerEvent -= SeePLayer;
    }

    private void StopMoving()
    {
        if(_isSeePlayer)
            _anim.Attack();
        else
            _anim.Stop();
    }

    private void StartMoving() =>
        _anim.Run();

    private void SeePLayer(Transform player)
    {
        _movement.FollowPlayer(player);
        _attack.SetPlayer(player);
        _isSeePlayer = true;
    }
}

