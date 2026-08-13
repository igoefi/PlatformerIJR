using System;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody2D),
    typeof(PlayerInput),
    typeof(StatsHandler))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _groundAngle;
    
    private bool _isCanJump = true;
    private float _xVelocity;
    private Rigidbody2D _body;
    private PlayerInput _playerInput;
    private StatsHandler _stats;
    
    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
        _playerInput = GetComponent<PlayerInput>();
        _stats = GetComponent<StatsHandler>();
        _body.gravityScale = _stats.FallGravityScale;
    }

    private void FixedUpdate()
    {
        _body.linearVelocityX = _xVelocity;
    }
    
    private void OnEnable()
    {
        _playerInput.JumpPressed += Jump;
        _playerInput.MovementPressed += SetVelocity;
        _playerInput.JumpUnpress += Fall;
    }

    private void OnDisable()
    {
        _playerInput.JumpPressed -= Jump;
        _playerInput.MovementPressed -= SetVelocity;
        _playerInput.JumpUnpress -= Fall;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        foreach (var collisionContact in other.contacts)
        {
            float angle = Vector2.Angle(collisionContact.normal, Vector2.up);
            if(angle <= _groundAngle)
                _isCanJump = true;
        }
    }

    private void Jump()
    {
        if(_isCanJump == false) return;
        
        _isCanJump = false;
        _body.gravityScale = _stats.NormalGravityScale;
        _body.AddForceY(_stats.JumpForce, ForceMode2D.Impulse);
    }

    private void Fall() =>
        _body.gravityScale = _stats.FallGravityScale;

    private void SetVelocity(Vector2 direction)
    {
        _xVelocity = direction.x * _stats.Speed;
    }
}
