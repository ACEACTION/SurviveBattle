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
        currentHp = maxHp;
        SetSliderValue();
    }

    public void SetMaxHp(float maxHp)
    {
        this.maxHp = maxHp;
        hpSlider.value = maxHp;
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

    public bool PlayerIsDead()
    {
        return currentHp <= 0;
    }


    void SetSliderValue()
    {
        hpSlider.value = currentHp;
    }

}
