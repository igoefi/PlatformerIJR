using System;
using UnityEngine;

[RequireComponent(typeof(EnemyPathTracingHandler),
    typeof(EnemyVision),
    typeof(EnemyMovement))]
public class MeleeEnemy : Enemy
{
    private EnemyPathTracingHandler _pathTracingHandler;
    private EnemyMovement  _movement;
    private EnemyVision _vision;

    private void Awake()
    {
        StatsHandler = GetComponent<StatsHandler>();
        _pathTracingHandler = GetComponent<EnemyPathTracingHandler>();
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

    private void StopMoving() =>
        InvokeStopEvent();
    
    private void StartMoving() =>
        InvokeMoveEvent();

    private void SeePLayer(Transform player) =>
        InvokeSeePlayerEvent(player);
}

