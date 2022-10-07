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

    public float deathPulseCd;
    public float deathPulseCdAmount;
}
