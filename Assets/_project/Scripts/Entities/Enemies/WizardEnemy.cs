using System;
using UnityEngine;

[RequireComponent(typeof(EnemyVision),
    typeof(EnemyMovement))]
public class WizardEnemy : Enemy
{
    private EnemyMovement  _movement;
    private EnemyVision _vision;

    private bool _isSeePlayer;
    
    private void Awake()
    {
        StatsHandler = GetComponent<StatsHandler>();
        _vision = GetComponent<EnemyVision>();
        _movement = GetComponent<EnemyMovement>();
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
        InvokeStopEvent();
        
        if(_isSeePlayer)
            InvokeAttackEvent();
    }
    
    private void StartMoving() =>
        InvokeMoveEvent();

    private void SeePLayer(Transform player)
    {
        InvokeSeePlayerEvent(player);
        _isSeePlayer = true;
    }
}

