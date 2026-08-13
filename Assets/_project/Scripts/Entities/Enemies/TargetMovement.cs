using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class TargetMovement : MonoBehaviour
{
    public event Action StopEvent;
    public event Action StartMovingEvent;
    
    [SerializeField] private float _normalMaxDistance;
    [SerializeField] private Enemy _handler;
    
    private float _needMaxDistance;
    private bool _isOnTarget;
    private bool _isStoping;
    private Transform _target;
    private Rigidbody2D _body;

    private Coroutine _stopCoroutine;
    
    private void Awake() =>
        _body = GetComponent<Rigidbody2D>();

    private void FixedUpdate()
    {
        if(!_target || _isStoping) return; 
        
        if (Math.Abs(transform.position.x - _target.position.x) <= _needMaxDistance)
        {
            if (_isOnTarget == false)
            {
                StopEvent?.Invoke();
                _isOnTarget = true;
            }

            _body.linearVelocityX = 0;
            return;
        }
        else if(_isOnTarget == true)
        {
            _isOnTarget = false;
            StartMovingEvent?.Invoke();
        }
        
        _body.linearVelocityX = Math.Sign(_target.position.x -transform.position.x) * _handler.StatsHandler.Speed;
    }

    public void SetTarget(Transform target)=>
        SetTargetParamets(target, _normalMaxDistance);

    public void SetTarget(Transform target, float maxDistance) =>
        SetTargetParamets(target, maxDistance);

    public void StopForTime(float time)
    {
        _stopCoroutine = StartCoroutine(WaitMoving(time));
    }

    private void SetTargetParamets(Transform target, float maxDistance)
    {
        if (_stopCoroutine != null)
        {
            StartCoroutine(WaitSetTarget(target, maxDistance));
            return;
        }
            
        _target = target;
        _needMaxDistance = maxDistance;
        _isOnTarget = false;
        StartMovingEvent?.Invoke();
    }
    
    private IEnumerator WaitMoving(float time)
    {
        _isStoping = true;
        _isOnTarget = true;
        StopEvent?.Invoke();
        
        yield return new WaitForSeconds(time);
        
        _isStoping = false;
        _stopCoroutine  = null;
    }

    private IEnumerator WaitSetTarget(Transform target, float maxDistance)
    {
        yield return _stopCoroutine;
        SetTargetParamets(target, maxDistance);
    }
}
