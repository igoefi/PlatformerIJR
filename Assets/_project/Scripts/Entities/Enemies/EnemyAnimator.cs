using System;
using UnityEngine;

[RequireComponent(typeof(Animator),  typeof(Enemy))]
public class EnemyAnimator : MonoBehaviour
{
    [SerializeField] private string _speedVariable;
    [SerializeField] private string _attackVariable;
    [SerializeField] private float _speed;
    
    private int _speedHash;
    private int _attackHash;
    
    private Animator _anim;
    
    private void Start()
    {
        _anim = GetComponent<Animator>();
        _speedHash = Animator.StringToHash(_speedVariable);
        _attackHash = Animator.StringToHash(_attackVariable);
    }

    public void Run()
    {
        _anim.SetFloat(_speedHash, _speed);
    }
    
    public void Stop()
    {
        _anim.SetFloat(_speedHash, 0);
    }

    public void Attack()
    {
        Stop();
        _anim.SetTrigger(_attackHash);
    }
}
