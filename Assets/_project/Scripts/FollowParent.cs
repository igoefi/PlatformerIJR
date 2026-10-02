using System;
using UnityEngine;

public class FollowParent : MonoBehaviour
{
    private Transform _target;
    private Vector3 _offset;
    
    private void Start()
    {
        _target = transform.parent;
        transform.SetParent(_target.parent, true);
        _offset = transform.position - _target.position;
    }

    private void Update() =>
        transform.position = _target.position + _offset;
}
