using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(TargetMovement))]
public class EnemyPathTracingHandler : MonoBehaviour
{
    [SerializeField] private Transform[]  _pathPoints;
    [SerializeField] private float _calmdownTime;
    private TargetMovement _movement;
    
    private int _pathPointIndex = 0;

    private void Awake()
    {
        _movement = GetComponent<TargetMovement>();
        _movement.SetTarget(_pathPoints[_pathPointIndex]);
    }

    private void OnEnable()
    {
        _movement.StopEvent += Calmdown;
    }

    private void OnDisable()
    {
        _movement.StopEvent -= Calmdown;
        StopAllCoroutines();
    }

    private void Calmdown()
    {
        _pathPointIndex++;
        
        if (_pathPointIndex >= _pathPoints.Length)
            _pathPointIndex = 0;
        
        StartCoroutine(CalmdownCoroutine());
    }
    
    private IEnumerator CalmdownCoroutine()
    {
        _movement.StopEvent -= Calmdown;
        
        yield return new WaitForSeconds(_calmdownTime);
        
        _movement.SetTarget(_pathPoints[_pathPointIndex]);
        _movement.StopEvent += Calmdown;
    }
}