using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "LightninStats")]
public class LightninStats : ScriptableObject
{
    public float radius;
    public float radiusDefault;

    public int count;
    public int countDefault;

    public int damage;
    public int damageDefault;

    public float maxCdDefault;
    public float maxCd;

    public void AddRadius(float r)
    {
        radius += r;
    }

    public void AddCount(int c)
    {
        count = c;
    }

    public void AddDamage(int dmg)
    {
        damage += dmg;
    }

    public void MinusMaxCd(float cd)
    {
        maxCd -= cd;
    }

    public void ResetStats()
    {
        count = countDefault;
        damage = damageDefault;
        maxCd = maxCdDefault;
        radius = radiusDefault;
    }

}
