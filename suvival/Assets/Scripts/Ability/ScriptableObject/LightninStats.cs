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

    public float cd;
    public float cdDefault;

}
