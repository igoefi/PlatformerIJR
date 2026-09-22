using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SpritesRotator : MonoBehaviour
{
    private Rigidbody2D _body;
    private Vector2 _normalRight;
    
    private void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        _normalRight = transform.right;
    }

    private void FixedUpdate()
    {
        float velocity = _body.linearVelocityX;

        if (velocity != 0)
            transform.right = velocity > 0 ? _normalRight : _normalRight * -1;
    }
}
