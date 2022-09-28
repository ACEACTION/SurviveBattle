using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Abilities/Satellite")]
public class SatelliteAbility : Ability
{
    public override void DoActive()
    {
        PlayerAbility_Satellite.PlayerAbilitySatellite();
    }
}
