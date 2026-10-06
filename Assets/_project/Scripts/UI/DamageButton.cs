using System;
using UnityEngine;
using UnityEngine.UI;

public class DamageButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Health _health;
    [SerializeField] private float _damage;

    private void OnEnable()
    {
        _button.onClick.AddListener(Damage);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(Damage);
    }

    private void Damage()
    {
        _health.TakeDamage(_damage);
    }
}
