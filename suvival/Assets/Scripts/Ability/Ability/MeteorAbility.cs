using System.Collections;
using System.Collections.Generic;
using UnityEngine;

# region Upgrade Level Desc
/*
    level 1: 2x count
    level 2: radius
    level 3: cd 
    level 4: dmg 
    level 5: 3x count
    level 6: radius
    level 7: cd
    level 8: dmg
    level 9: 4x count
    level 10: dmg
*/
#endregion

[CreateAssetMenu(menuName = "Abilities/Meteor Ability")]
public class MeteorAbility : Ability
{
    [SerializeField] MeteorStats stats;
    [SerializeField] int countLevel1;
    [SerializeField] float radiusLevel2;
    [SerializeField] float cdLevel3;
    [SerializeField] int dmgLevel4;
    [SerializeField] int countLevel5;
    [SerializeField] float radiusLevel6;
    [SerializeField] float cdLevel7;
    [SerializeField] int dmgLevel8;
    [SerializeField] int countLevel9;
    [SerializeField] int dmgLevel10;

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
                PlayerAbility_Meteor.DoActiveAbilityAction();
                stats.SetCounter(countLevel1);
                break;
            case 2:
                stats.AddRadius(radiusLevel2);
                break;
            case 3:
                stats.MinusCd(cdLevel3);
                break;
            case 4:
                stats.AddDmg(dmgLevel4);
                break;
            case 5:
                stats.SetCounter(countLevel5);
                break;
            case 6:
                stats.AddRadius(radiusLevel6);
                break;
            case 7:
                stats.MinusCd(cdLevel7);
                break;
            case 8:
                stats.AddDmg(dmgLevel8);
                break;
            case 9:
                stats.SetCounter(countLevel9);
                break;
            case 10:
                stats.AddDmg(dmgLevel10); 
                break;
        }
    }
}
