using System;
using UnityEngine;

[RequireComponent(typeof(TargetMovement), 
    typeof(EnemyPathTracingHandler), 
    typeof(PlayerFollower))]
public class EnemyMovement : MonoBehaviour
{
    private TargetMovement _targetMovement;
    private EnemyPathTracingHandler  _pathTracingHandler;
    private PlayerFollower _playerFollower;
    
    public event Action StopEvent;
    public event Action MovingEvent;

    private void Awake()
    {
        _targetMovement = GetComponent<TargetMovement>();
        _pathTracingHandler = GetComponent<EnemyPathTracingHandler>();
        _playerFollower = GetComponent<PlayerFollower>();
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
        _playerFollower.FollowPlayer(player);
    }

    private void StartMoving()
    {
        MovingEvent?.Invoke();
    }
}
