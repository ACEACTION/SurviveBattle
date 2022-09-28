using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Abilities/Satellite")]
public class SatelliteAbility : Ability
{
    [SerializeField] float abilityLevel4Speed;
    [SerializeField] float abilityLevel5Speed;

    public override void DoActive()
    {
        if (abilityLevel > maxAbilityLevel) return;

        if (abilityLevel <= 2)
        {
            PlayerAbility_Satellite.PlayerAbilitySatellite();
        }
        else if (abilityLevel == 3)
        {
            PlayerAbility_Satellite.UpgradeSatelliteSpeed(abilityLevel4Speed);
        }
        else if (abilityLevel == 4)
        {
            PlayerAbility_Satellite.UpgradeSatelliteSpeed(abilityLevel5Speed);
        }

        abilityLevel++;
    }
}
