using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D),
    typeof(SpriteRenderer), 
    typeof(Animator))]
public class AnimationHandler : MonoBehaviour
{
    [SerializeField] private string _speedVariable;
    
    private Animator _anim;
    private Rigidbody2D _body;
    private SpriteRenderer _sprite;
    private int _speedHash;
    
    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _body = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
        _speedHash = Animator.StringToHash(_speedVariable);
    }

    private void FixedUpdate()
    {
        float velocity = _body.linearVelocityX;
        
        if(velocity != 0)
            _sprite.flipX = velocity < 0;
        
        _anim.SetFloat(_speedHash, Math.Abs(_body.linearVelocityX));
    }
}
