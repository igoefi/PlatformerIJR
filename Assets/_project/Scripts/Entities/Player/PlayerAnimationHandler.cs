using System;
using UnityEngine;

[RequireComponent(typeof(Animator),
    typeof(PlayerInput),
    typeof(StatsHandler))]
public class PlayerAnimationHandler : MonoBehaviour
{
    [SerializeField] private string _speedVariable;
    [SerializeField] private string _attackVariable;
    
    private Animator _anim;
    private PlayerInput _playerInput;
    private StatsHandler  _stats;
    private int _speedHash;
    private int _attackHash;
    
    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _playerInput = GetComponent<PlayerInput>();
        _stats = GetComponent<StatsHandler>();
        _speedHash = Animator.StringToHash(_speedVariable);
        _attackHash = Animator.StringToHash(_attackVariable);
    }

    private void OnEnable()
    {
        _playerInput.MovementPressed += SetSpeedAnimation;
        _playerInput.AttackPressed += SetAttackTrigger;
    }

    private void OnDisable()
    {
        _playerInput.MovementPressed -= SetSpeedAnimation;
        _playerInput.AttackPressed -= SetAttackTrigger;
    }

    private void SetSpeedAnimation(Vector2 movement)
    {
        float speed = Math.Abs(movement.x * _stats.Speed);
        _anim.SetFloat(_speedHash, speed);
    }

    private void SetAttackTrigger()
    {
        _anim.SetTrigger(_attackHash);
    }
}