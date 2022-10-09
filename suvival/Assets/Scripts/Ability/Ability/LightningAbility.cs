using System.Collections;
using System.Collections.Generic;
using UnityEngine;

# region Upgrade Level Desc
/*
    level 1: 1x count
    level 2: dmg
    level 3: cd
    level 4: radius
    level 5: 2x count
    level 6: dmg 
    level 7: cd
    level 8: radius
    level 9: 3x count
    level 10: dmg
*/
#endregion

[CreateAssetMenu(menuName = "Abilities/Lightning")]
public class LightningAbility : Ability
{

    [SerializeField] LightninStats stats;
    [SerializeField] int dmgLevel2;
    [SerializeField] float cdLevel3;
    [SerializeField] float radiusLevel4;
    [SerializeField] int countLevel5;
    [SerializeField] int dmgLevel6;
    [SerializeField] float cdLevel7;
    [SerializeField] float radiusLevel8;
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
                PlayerAbility_Lightning.DoActiveAbilityAction();
                break;
            case 2:
                stats.AddDamage(dmgLevel2);
                break;
            case 3:
                stats.MinusMaxCd(cdLevel3);
                break;
            case 4:
                stats.AddRadius(radiusLevel4);
                break;
            case 5:
                stats.AddCount(countLevel5);
                break;
            case 6:
                stats.AddDamage(dmgLevel6);
                break;
            case 7:
                stats.MinusMaxCd(cdLevel7);
                break;
            case 8:
                stats.AddRadius(radiusLevel8);
                break;
            case 9:
                stats.AddCount(countLevel9);
                break;
            case 10:
                stats.AddDamage(dmgLevel10);
                break;
        }
    }
}


