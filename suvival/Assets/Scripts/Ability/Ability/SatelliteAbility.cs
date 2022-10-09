using System.Collections;
using System.Collections.Generic;
using UnityEngine;


# region upgrade levels desc
/* 
    level 1 = 2x count 
    level 2 = dmg
    level 3 = speed
    level 4 = dmg
    level 5 = 3x count
    level 6 = speed
    level 7 = dmg
    level 8 = speed
    level 9 = dmg
    level 10 = 4x count
 */

#endregion


[CreateAssetMenu(menuName = "Abilities/Satellite")]
public class SatelliteAbility : Ability
{
    [SerializeField] SatelliteStats stats;
    [SerializeField] int dmgLevel2;
    [SerializeField] int speedLevel3;
    [SerializeField] int dmgLevel4;
    [SerializeField] int speedLevel6;
    [SerializeField] int dmgLevel7;        
    [SerializeField] int speedLevel8;
    [SerializeField] int dmgLevel9;


    public override void ResetAbility()
    {
        base.ResetAbility();
        stats.ResetStats();
    }



    public override void DoActive()
    {
        base.DoActive();
        switch (abilityLevel)
        {
            case 1:
                PlayerAbility_Satellite.AddSatellite();
                break;
            case 2:
                stats.AddDmg(dmgLevel2);
                break;
            case 3:
                stats.AddSpeed(speedLevel3);
                break;
            case 4:
                stats.AddDmg(dmgLevel4);
                break;
            case 5:
                PlayerAbility_Satellite.AddSatellite();
                break;
            case 6:
                stats.AddSpeed(speedLevel6);
                break;
            case 7:
                stats.AddDmg(dmgLevel7);
                break;
            case 8:
                stats.AddSpeed(speedLevel8);
                break;
            case 9:
                stats.AddDmg(dmgLevel9);
                break;
            case 10:
                PlayerAbility_Satellite.AddSatellite();
                break;

        }

    }

}
