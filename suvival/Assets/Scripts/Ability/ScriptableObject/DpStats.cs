using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="DPStats")]
public class DpStats : ScriptableObject
{
    public float radius;
    public float radiusDefault;

    public int count;
    public int countDefault;

    public float maxDeathPulseCd;
    public float defaultMaxDeathPulseCd;

    public int dmg;
    public int defaultDmg;

    public void SetCount(int c)
    {
        count = c;
    }

    public void MinusDeathPulsCd(float cd)
    {
        maxDeathPulseCd -= cd;
    }

    public void AddDmg(int d)
    {
        dmg += d;
    }

    public void ResetStats()
    {
        count = countDefault;
        dmg = defaultDmg;
        maxDeathPulseCd = defaultMaxDeathPulseCd;
    }

}
