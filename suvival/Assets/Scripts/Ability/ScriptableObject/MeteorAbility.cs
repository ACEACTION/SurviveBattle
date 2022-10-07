using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region meteor level desc
/*
    level 1 = active ability with 2x meteor counter
    level 2 = minus make meteor cd
    level 3 = increase meteor area scale
    level 4 = 3x meteor counter
    level 5 = minus make meteor cd
    level 6 = increase meteor area scale
    level 7 = 4x meteor counter
    level 8 = minus make meteor cd
    level 9 = increase meteor area scale
    level 10 = 5x meteor counter
*/
#endregion

[CreateAssetMenu(menuName = "Abilities/Meteor Ability")]
public class MeteorAbility : Ability
{
    [SerializeField] MeteorStats meteorStats;

    [Header("Upgrade levels")]
    [SerializeField] float minusMeteorCdLevel2;
    [SerializeField] float meteorAreaScaleLevel3;
    [SerializeField] int meteorCounterLevel4;
    [SerializeField] float minusMeteorCdLevel5;
    [SerializeField] float meteorAreaScaleLevel6;
    [SerializeField] int meteorCounterLevel7;
    [SerializeField] float minusMeteorCdLevel8;
    [SerializeField] float meteorAreaScaleLevel9;
    [SerializeField] int meteorCounterLevel10;


    public override void ResetAbility()
    {
        base.ResetAbility();
        meteorStats.ResetMeteorAreaStats();
    }

    public override void DoActive()
    {
        base.DoActive();

        switch (abilityLevel)
        {
            case 1:
                PlayerAbility_Meteor.DoActiveAbilityAction();
                break;
            case 2:
                meteorStats.MinusMakeMeteorCd(minusMeteorCdLevel2);
                break;
            case 3:
                meteorStats.AddMeteorAreaScale(meteorAreaScaleLevel3);
                break;
            case 4:
                meteorStats.AddMeteorCounter(meteorCounterLevel4);
                break;
            case 5:
                meteorStats.MinusMakeMeteorCd(minusMeteorCdLevel5);
                break;
            case 6:
                meteorStats.AddMeteorAreaScale(meteorAreaScaleLevel6);
                break;
            case 7:
                meteorStats.AddMeteorCounter(meteorCounterLevel7);
                break;
            case 8:
                meteorStats.MinusMakeMeteorCd(minusMeteorCdLevel8);
                break;
            case 9:
                meteorStats.AddMeteorAreaScale(meteorAreaScaleLevel9);
                break;
            case 10:
                meteorStats.AddMeteorCounter(meteorCounterLevel10);
                break;            
        }
    }
}
