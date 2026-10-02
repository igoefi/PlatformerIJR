using UnityEngine;
using UnityEngine.UI;

public class SimpleHPBar : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Image _image;
    private void OnEnable()
    {
        _health.HealEvent += SetImage;
        _health.GetDamageEvent += SetImage;
        _health.DieEvent += SetImage;
    }

    private void OnDisable()
    {
        _health.HealEvent -= SetImage;
        _health.GetDamageEvent -= SetImage;
        _health.DieEvent -= SetImage;
    }

    private void SetImage() =>
        _image.fillAmount = _health.HealthCount / _health.MaxHealthCount;
}
