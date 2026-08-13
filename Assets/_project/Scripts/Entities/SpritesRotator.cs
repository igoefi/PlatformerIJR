using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SpritesRotator : MonoBehaviour
{
    private Rigidbody2D _body;
    private float _normalXScale;

    private void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        _normalXScale = transform.localScale.x;
    }

    private void FixedUpdate()
    {
        float velocity = _body.linearVelocityX;
        
        if(velocity != 0)
            transform.localScale = new Vector2(velocity > 0 ? _normalXScale : _normalXScale * -1,
                transform.localScale.y);
    }
}
