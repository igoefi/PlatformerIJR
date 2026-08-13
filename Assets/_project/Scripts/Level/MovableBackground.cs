using System;
using UnityEngine;

public class MovableBackground : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private Transform _mainCamera;
    private float _lastCameraXPosition;

    private void Start()
    {
        _mainCamera = Camera.main.transform;
        _lastCameraXPosition = _mainCamera.position.x;
    }

    private void Update()
    {
        float deltaMovement = _mainCamera.position.x - _lastCameraXPosition;
        
        if(deltaMovement == 0)
            return;
        
        transform.position = new Vector3(transform.position.x + deltaMovement * _speed * Time.deltaTime,
            transform.position.y, transform.position.z);
        _lastCameraXPosition = _mainCamera.position.x;
    }
}
