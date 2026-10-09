using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class VampirizmView : MonoBehaviour
{
    [SerializeField] private Image _abilityRange;
    [SerializeField] private Image _imageBar;
    [SerializeField] private Vampirizm _vampirizm;

    private void OnEnable()
    {
        _vampirizm.StartAbility += () => SetAbilityRangeVisible(true);
        _vampirizm.EndAbility += () => SetAbilityRangeVisible(false);
        _vampirizm.OnChangeTimeState += SetAbilityBarState;
    }

    private void OnDisable()
    {
        _vampirizm.StartAbility -= () => SetAbilityRangeVisible(true);
        _vampirizm.EndAbility -= () => SetAbilityRangeVisible(false);
        _vampirizm.OnChangeTimeState -= SetAbilityBarState;
    }

    public void SetAbilityRangeVisible(bool isVisible)
    {
        _abilityRange.gameObject.SetActive(isVisible);
    }

    public void SetAbilityBarState(float value)
    {
        _imageBar.fillAmount = value;
    }
}
