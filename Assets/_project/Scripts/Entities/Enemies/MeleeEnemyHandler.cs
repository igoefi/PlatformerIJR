using System;
using UnityEngine;

[RequireComponent(typeof(EnemyPathTracingHandler),
    typeof(EnemyVision),
    typeof(EnemyMovementHandler))]
public class MeleeEnemyHandler : EnemyHandler
{
    private EnemyPathTracingHandler _pathTracingHandler;
    private EnemyMovementHandler  _movementHandler;
    private EnemyVision _vision;
    
    void Awake()
    {
        StatsHandler = GetComponent<StatsHandler>();
        _pathTracingHandler = GetComponent<EnemyPathTracingHandler>();
        _vision = GetComponent<EnemyVision>();
        _movementHandler = GetComponent<EnemyMovementHandler>();
    }

    private void OnEnable()
    {
        _movementHandler.MovingEvent += StartMoving;
        _movementHandler.StopEvent += StopMoving;
        _vision.SeePlayerEvent += SeePLayer;
    }

    private void OnDisable()
    {
        _movementHandler.MovingEvent -= StartMoving;
        _movementHandler.StopEvent -= StopMoving;
        _vision.SeePlayerEvent -= SeePLayer;
    }

    private void StopMoving() =>
        InvokeStopEvent();
    
    private void StartMoving() =>
        InvokeMoveEvent();

    private void SeePLayer(Transform player) =>
        InvokeSeePlayerEvent(player);
}

