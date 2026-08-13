using System;
using UnityEngine;

[RequireComponent(typeof(Animator),  typeof(EnemyHandler))]
public class EnemyAnimationHandler : MonoBehaviour
{
    [SerializeField] private string _speedVariable;
    [SerializeField] private string _attackVariable;
    [SerializeField] EnemyHandler _handler;
    
    private int _speedHash;
    private int _attackHash;
    
    private Animator _anim;
    
    private void Start()
    {
        _anim = GetComponent<Animator>();
        _speedHash = Animator.StringToHash(_speedVariable);
        _attackHash = Animator.StringToHash(_attackVariable);
    }

    private void OnEnable()
    {
        _handler.MoveEvent += Run;
        _handler.StopEvent += Stop;
        _handler.AttackEvent += Attack;
    }

    private void OnDisable()
    {
        _handler.MoveEvent -= Run;
        _handler.StopEvent -= Stop;
        _handler.AttackEvent -= Attack;
    }

    private void Run()
    {
        _anim.SetFloat(_speedHash, _handler.StatsHandler.Speed);
    }
    
    private void Stop()
    {
        _anim.SetFloat(_speedHash, 0);
    }

    private void Attack()
    {
        _anim.SetTrigger(_attackHash);
    }
}
