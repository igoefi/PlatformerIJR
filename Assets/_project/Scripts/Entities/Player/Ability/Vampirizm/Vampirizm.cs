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

    public Action<float> OnChangeTimeState;
    public Action StartAbility;
    public Action EndAbility;
    
    private void Start()
    {
        _damageWait = new WaitForSeconds(_timePerDamage);
        _cooldownWait = new WaitForSeconds(_cooldownTime);
    }

    private void OnEnable()
    {
        GetComponent<PlayerInput>().VampirizmPressed += StartAttack;
    }

    private void OnDisable()
    {
        GetComponent<PlayerInput>().VampirizmPressed -= StartAttack;
    }

    private void StartAttack()
    {
        if(_attackCoroutine != null)
            return;

        _attackCoroutine = StartCoroutine(AttackCoroutine());
    }

    private IEnumerator AttackCoroutine()
    {
        StartAbility?.Invoke();
        float time = 0;

        while (time < _abilityTime)
        {
            if (_damager.VampireAttack(_damage, _radius, out float heal))
                _health.Heal(heal);
            
            yield return _damageWait;
            
            time += _timePerDamage;
            OnChangeTimeState?.Invoke(1 - time/_abilityTime);
        }
        
        EndAbility?.Invoke();
        
        while (time > 0)
        {
            yield return _damageWait;
            
            time -= _timePerDamage;
            OnChangeTimeState?.Invoke(1 - time/_abilityTime);
        }
        
        _attackCoroutine = null;
    }
}
