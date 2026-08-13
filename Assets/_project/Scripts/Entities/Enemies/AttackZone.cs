using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class AttackZone : MonoBehaviour
{
    [SerializeField] private LayerMask _ignoreMask;
    private Collider2D _collider;
    
    public IDamagable[] GetColliders()
    {
        
        return null;
    } 
}