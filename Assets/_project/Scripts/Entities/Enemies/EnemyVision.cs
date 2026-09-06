using System;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    [SerializeField] private LayerMask _ignoreLayers;
    [SerializeField] private EnemyVisionCollider _viewField;

    public event Action <Transform> SeePlayerEvent;

    private void OnEnable()
    {
        _viewField.SeePlayer += CheckSeePlayer;
    }

    private void OnDisable()
    {
        _viewField.SeePlayer -= CheckSeePlayer;
    }

    private void CheckSeePlayer(Collider2D player)
    {
        Vector2 direction = player.transform.position + 
                            new Vector3(player.offset.x, player.offset.y) - transform.position;
        float distance = direction.magnitude;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction.normalized, distance, ~_ignoreLayers);
        
        if(hit.collider == player)
            SeePlayerEvent?.Invoke(player.transform);
    }
}
