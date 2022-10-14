using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] float maxHp;
    [SerializeField] float currentHp;
    [SerializeField] Slider hpSlider;

    private void Start()
    {
        SetSliderValue();
    }

    public void SetHp(float maxHp)
    {
        this.maxHp = maxHp;
        hpSlider.maxValue = maxHp;
        currentHp = maxHp;
    }

    public void MinusHp(float hp)
    {
        currentHp -= hp;
        SetSliderValue();
    }

    public void AddHp(float hp)
    {
        currentHp += hp;
        SetSliderValue();
    }

    void SetSliderValue()
    {
        hpSlider.value = currentHp;
    }

}
