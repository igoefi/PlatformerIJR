using System;
using TMPro;
using UnityEngine;

public class TextHPBar : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Health _health;

    private void OnEnable()
    {
        _health.HealEvent += SetText;
        _health.GetDamageEvent += SetText;
        _health.DieEvent += SetText;
    }

    private void OnDisable()
    {
        _health.HealEvent -= SetText;
        _health.GetDamageEvent -= SetText;
        _health.DieEvent -= SetText;
    }

    private void SetText() =>
        _text.text = $"{_health.Count}/{_health.MaxCount}";
}
