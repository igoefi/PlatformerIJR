using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class VampirizmView : MonoBehaviour
{
    [SerializeField] private Image _sprite;
    [SerializeField] private Image _imageBar;
    [SerializeField] private float _changeBarPerTime;

    private WaitForSeconds _changeBarWait;

    private void Start()
    {
        _changeBarWait = new WaitForSeconds(_changeBarPerTime);
    }

    public void StartAbility(float time)
    {
        StartCoroutine(IncreaseDecreaseBar(time, true));
        _sprite.gameObject.SetActive(true);
    }

    public void StartCooldown(float time)
    {
        StartCoroutine(IncreaseDecreaseBar(time, false));
        _sprite.gameObject.SetActive(false);
    }

    private IEnumerator IncreaseDecreaseBar(float time, bool increase)
    {
        float value = 0;

        while (value < time)
        {
            yield return _changeBarWait;
            value += _changeBarPerTime;
            
            if(value > time)
                value = time;
            
            if(increase) 
                _imageBar.fillAmount = 1 - value / time;
            else
                _imageBar.fillAmount = value / time;
        }
    }
}
