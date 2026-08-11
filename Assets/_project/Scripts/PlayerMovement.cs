using System;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _fallGravityScale;
    [SerializeField] private float _normalGravityScale;
    [SerializeField] private float _groundAngle;
    
    private bool _isCanJump = true;
    private float _xVelocity;
    private Rigidbody2D _body;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
        _body.gravityScale = _fallGravityScale;
    }

    private void FixedUpdate()
    {
        _body.linearVelocityX = _xVelocity;
    }
    
    private void OnEnable()
    {
        PlayerInput.JumpPressed += Jump;
        PlayerInput.MovementPressed += SetVelocity;
        PlayerInput.JumpUnpress += Fall;
    }

    private void OnDisable()
    {
        PlayerInput.JumpPressed -= Jump;
        PlayerInput.MovementPressed -= SetVelocity;
        PlayerInput.JumpUnpress -= Fall;
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
        _body.gravityScale = _normalGravityScale;
        _body.AddForceY(_jumpForce, ForceMode2D.Impulse);
    }

    private void Fall() =>
        _body.gravityScale = _fallGravityScale;

    private void SetVelocity(Vector2 direction)
    {
        _xVelocity = direction.x * _speed;
    }
}
