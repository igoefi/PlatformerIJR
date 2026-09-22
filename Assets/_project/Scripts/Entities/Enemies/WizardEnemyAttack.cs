using System;
using UnityEditorInternal;
using UnityEngine;

[RequireComponent(typeof(WizardEnemy))]
public class WizardEnemyAttack : MonoBehaviour
{
    [SerializeField] private Explosion _wizardAttackPrefab;
    
    private Transform _player;
    private float _damage;
    
    public void SetDamage(float damage) =>
        _damage = damage;
        
    public void SetPlayer(Transform player) =>
        _player = player;
    
    public void CreateExplosion()
    {
        Explosion explode = Instantiate(_wizardAttackPrefab, _player);
        explode.transform.localPosition = new Vector2(0, -_player.position.y);
        explode.SetDamage(_damage);
    }
}
