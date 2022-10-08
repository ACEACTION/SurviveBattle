using System.Collections;
using System.Collections.Generic;
using UnityEngine;


#region ability level desc
/* 
    level 1 = 5x count
    level 2 = 7x count
    level 3 = cd
    level 4 = dmg
    level 5 = 10x count
    level 6 = dmg
    level 7 = cd
    level 8 = 12x count
    level 9 = 14x count
    level 10 = 16x count
 */
#endregion

[CreateAssetMenu(menuName = "Abilities/DeathPuls")]
public class DeathPulsAbility : Ability
{
    [SerializeField] DpStats stats;
    [SerializeField] int countLevel1;
    [SerializeField] int countLevel2;
    [SerializeField] float cdLevel3;
    [SerializeField] int dmgLevel4;
    [SerializeField] int countLevel5;
    [SerializeField] int dmgLevel6;
    [SerializeField] float cdLevel7;
    [SerializeField] int countLevel8;
    [SerializeField] int countLevel9;
    [SerializeField] int countLevel10;

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
                PlayerAbility_DeathPulse.DoActiveAbilityAction();
                stats.SetCount(countLevel1);
                break;
            case 2:
                stats.SetCount(countLevel2);
                break;
            case 3:
                stats.MinusDeathPulsCd(cdLevel3);
                break;
            case 4:
                stats.AddDmg(dmgLevel4);
                break;
            case 5:
                stats.SetCount(countLevel5);
                break;
            case 6:
                stats.AddDmg(dmgLevel6);
                break;
            case 7:
                stats.MinusDeathPulsCd(cdLevel7);
                break;
            case 8:
                stats.SetCount(countLevel8);
                break;
            case 9:
                stats.SetCount(countLevel9);
                break;
            case 10:
                stats.SetCount(countLevel10);
                break;
        }
    }
}
