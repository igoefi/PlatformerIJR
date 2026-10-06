using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Image _image;
    [SerializeField] private float _changeStep;
    [SerializeField] private float _changeTime;

    private Coroutine _barCoroutine;
    private float _barFloat = 1;
    private WaitForSeconds _stepTime;

    private void Start()
    {
        _stepTime = new WaitForSeconds(_changeTime);
        
        if(_health.HealthCount / _health.MaxHealthCount != 1)
            SetImage();
    }

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

    private void SetImage()
    {
        if(_barCoroutine != null)
            StopCoroutine(_barCoroutine);

        float value = _health.HealthCount / _health.MaxHealthCount;
        
        if(value == _barFloat)
            return;

        _barCoroutine = StartCoroutine(SetImageCoroutine(value));
    }

    private IEnumerator SetImageCoroutine(float value)
    {
        while (_barFloat != value)
        {
            _barFloat = Mathf.MoveTowards(_barFloat,value, _changeStep);
            _image.fillAmount = _barFloat;
           
            yield return _stepTime;
        }
    }
}
