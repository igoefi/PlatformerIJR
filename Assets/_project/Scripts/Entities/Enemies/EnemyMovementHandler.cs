using System;
using UnityEngine;

[RequireComponent(typeof(TargetMovement), 
    typeof(EnemyPathTracingHandler), 
    typeof(FollowPlayerHandler))]
public class EnemyMovementHandler : MonoBehaviour
{
    public event Action StopEvent;
    public event Action MovingEvent;

    [SerializeField] private EnemyHandler _handler;
    
    private TargetMovement _targetMovement;
    private EnemyPathTracingHandler  _pathTracingHandler;
    private FollowPlayerHandler _followPlayerHandler;

    private void Awake()
    {
        _targetMovement = GetComponent<TargetMovement>();
        _pathTracingHandler = GetComponent<EnemyPathTracingHandler>();
        _followPlayerHandler = GetComponent<FollowPlayerHandler>();
    }

    private void OnEnable()
    {
        _targetMovement.StopEvent += Stop;
        _targetMovement.StartMovingEvent += StartMoving;
    }

    private void OnDisable()
    {
        _targetMovement.StopEvent -= Stop;
        _targetMovement.StartMovingEvent -= StartMoving;
    }

    public void Stop()
    {
        StopEvent?.Invoke();
    }
    
    public void FollowPlayer(Transform player)
    {
        _pathTracingHandler.enabled = false;
        _followPlayerHandler.FollowPlayer(player);
    }

    private void StartMoving()
    {
        MovingEvent?.Invoke();
    }
}
