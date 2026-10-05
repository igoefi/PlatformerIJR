using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class Vampirizm : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private VampirizmView _view;
    [SerializeField] private VampirizmDamager _damager;

    [Header("Ability preferences")] 
    [SerializeField] private float _radius;
    [SerializeField] private float _damage;
    [SerializeField] private float _abilityTime;
    [SerializeField] private float _cooldownTime;
    [SerializeField] private float _timePerDamage;

    private Coroutine _attackCoroutine;
    private WaitForSeconds _damageWait;
    private WaitForSeconds _cooldownWait;
    
    
    private void Start()
    {
        GetComponent<PlayerInput>().VampirizmPressed += StartAttack;
        _damageWait = new WaitForSeconds(_timePerDamage);
        _cooldownWait = new WaitForSeconds(_cooldownTime);
    }

    private void StartAttack()
    {
        if(_attackCoroutine != null)
            return;

        _attackCoroutine = StartCoroutine(AttackCoroutine());
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private IEnumerator AttackCoroutine()
    {
        _view.StartAbility(_abilityTime);
        float time = 0;

        while (time <= _abilityTime)
        {
            if (_damager.VampireAttack(_damage, _radius))
            {
                _health.Heal(_damage);
                Debug.Log(1);
            }
            Debug.Log(2);
            
            yield return _damageWait;
            time += _timePerDamage;
        }
        
        _view.StartCooldown(_cooldownTime);
        yield return _cooldownWait;
        _attackCoroutine = null;
    }
}
