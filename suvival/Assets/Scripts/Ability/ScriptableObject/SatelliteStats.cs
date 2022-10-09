using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( menuName = "Stats/Satellite Stats")]
public class SatelliteStats : ScriptableObject
{
    public int satelliteSpeed;
    [SerializeField] int defaultSatelliteSpeed;
    public int dmg;
    [SerializeField] int defaultDmg;

    public void ResetStats()
    {
        satelliteSpeed = defaultSatelliteSpeed;
        dmg = defaultDmg;
    }

    public void AddSpeed(int s)
    {
        satelliteSpeed += s;
    }

    public void AddDmg(int d)
    {
        dmg += d;
    }

}
