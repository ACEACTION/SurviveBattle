using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] int maxHp;
    [SerializeField] int currentHp;
    [SerializeField] Slider hpSlider;

    private void Start()
    {
        currentHp = maxHp;
        SetSliderValue();
    }

    public void SetMaxHp(int maxHp)
    {
        this.maxHp = maxHp;
        hpSlider.value = maxHp;
    }

    public void MinusHp(int hp)
    {
        currentHp -= hp;
        SetSliderValue();
    }

    public void AddHp(int hp)
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
