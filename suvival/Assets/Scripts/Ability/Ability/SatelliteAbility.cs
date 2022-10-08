using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region ability level desc
/* 
    level 1 = 2x satellites
    level 2 = 3x satellites
    level 3 = 4x satellites
    level 4 = increase satellites speed 
    level 5 = increase satellites speed 
 */
#endregion

[CreateAssetMenu(menuName = "Abilities/Satellite")]
public class SatelliteAbility : Ability
{
    [SerializeField] float abilityLevel4Speed;
    [SerializeField] float abilityLevel5Speed;

    public override void DoActive()
    {
        base.DoActive();


        switch (abilityLevel)
        {
            case 1:
                PlayerAbility_Satellite.GetPlayerAbilitySatellite().ActiveLevel1();
                break;
            case 2:
                PlayerAbility_Satellite.GetPlayerAbilitySatellite().ActiveLevel2();
                break;
            case 3:
                PlayerAbility_Satellite.GetPlayerAbilitySatellite().ActiveLevel3();
                break;
            case 4:
                PlayerAbility_Satellite.GetPlayerAbilitySatellite().UpgradeSpeed(abilityLevel4Speed);
                break;
            case 5:
                PlayerAbility_Satellite.GetPlayerAbilitySatellite().UpgradeSpeed(abilityLevel5Speed);
                break;
        }
    }



}
