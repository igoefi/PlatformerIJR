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
        _movement.OnTargetEvent += Calmdown;
        _movement.SetTarget(_pathPoints[_pathPointIndex]);
    }

    private void Calmdown()
    {
        _pathPointIndex++;
        
        if (_pathPointIndex >= _pathPoints.Length)
            _pathPointIndex = 0;
        
        _movement.SetTarget(_pathPoints[_pathPointIndex]);
        StartCoroutine(CalmdownCoroutine());
    }
    
    private IEnumerator CalmdownCoroutine()
    {
        _movement.OnTargetEvent -= Calmdown;
        _movement.enabled = false;
        
        yield return new WaitForSeconds(_calmdownTime);
        
        _movement.enabled = true;
        _movement.OnTargetEvent += Calmdown;
    }
}