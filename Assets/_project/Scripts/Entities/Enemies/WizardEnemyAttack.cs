using System;
using UnityEngine;

[RequireComponent(typeof(WizardEnemy))]
public class WizardEnemyAttack : MonoBehaviour
{
    [SerializeField] private Explosion _wizardAttackPrefab;
    
    private WizardEnemy _handler;
    private Transform _player;

    private void Awake()
    {
        _handler = GetComponent<WizardEnemy>();
    }

    private void OnEnable()
    {
        _handler.SeePlayerEvent += SetPlayer;
    }

    private void OnDisable()
    {
        _handler.SeePlayerEvent -= SetPlayer;
    }

    private void SetPlayer(Transform player) =>
        _player  = player;
    
    public void CreateExplosion()
    {
        Explosion explode = Instantiate(_wizardAttackPrefab, _player);
        explode.transform.localPosition = new Vector2(0, -_player.position.y);
        explode.SetDamage(_handler.StatsHandler.Damage);
    }
}
