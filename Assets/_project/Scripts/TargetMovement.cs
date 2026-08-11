using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class TargetMovement : MonoBehaviour
{
    public delegate void OnTarget();
    public event OnTarget OnTargetEvent;
    
    [SerializeField] private float _speed;
    [SerializeField] private float _maxDistance;
    private Transform _target;
    private Rigidbody2D _body;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if(!_target) return; 
        
        _body.linearVelocityX = Math.Sign(_target.position.x -transform.position.x) * _speed;
        
        if (Math.Abs(transform.position.x - _target.position.x) <= _maxDistance)
        {
            _body.linearVelocityX = 0;
            OnTargetEvent?.Invoke();
        }
    }

    public void SetTarget(Transform target) =>
        _target = target;
}
