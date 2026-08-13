using System;
using UnityEngine;

[RequireComponent(typeof(StatsHandler))]
public abstract class Enemy : MonoBehaviour
{
    public event Action MoveEvent;
    public event Action StopEvent;
    public event Action AttackEvent;
    public event Action<Transform> SeePlayerEvent;
    
    public StatsHandler StatsHandler { get; protected set; }
    
    protected void InvokeMoveEvent() =>
        MoveEvent?.Invoke();
    protected void InvokeStopEvent() =>
        StopEvent?.Invoke();
    protected void InvokeAttackEvent() =>
        AttackEvent?.Invoke();
    protected void InvokeSeePlayerEvent(Transform player) =>
        SeePlayerEvent?.Invoke(player);
}
