using Newtonsoft.Json.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Stats/LightninStats")]
public class LightninStats : ScriptableObject
{
    public float aoeRadius = 50f;
    public float aoeRadiusDefault = 50f;

    public int count;
    public int countDefault;

    public int damage;
    public int damageDefault;

    public float maxCd;
    public float maxCdDefault;


    public void ResetStats()
    {
        aoeRadius = aoeRadiusDefault;
        count = countDefault;
        damage = damageDefault;
        maxCd = maxCdDefault;
    }

    public void AddDamage(int d)
    {
        damage += d;
    }

    public void SetCount(int c) 
    { 
        count = c; 
    }

    public void AddRadius(float r) {
        aoeRadius += r;
    }

    public void MinusMaxCd(float c)
    {
        maxCd -= c;
    }
}
