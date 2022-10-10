using System.Collections;
using System.Collections.Generic;
using UnityEngine;

# region Upgrade Level Desc
/*
    level 1: ad
    level 2: as
    level 3: 2x diagonal
    level 4: proj move speed
    level 5: as
    level 6: side arrows
    level 7: ad
    level 8: proj move speed
    level 9: ad
    level 10: as
*/
#endregion
[CreateAssetMenu(menuName = "Abilities/Projectile Ability")]
public class ProjectileAbility : Ability
{
    [SerializeField] ProjectileStats stats;
    [SerializeField] int adLevel1;
    [SerializeField] int asLevel2;    
    [SerializeField] int projecMoveSpeedLevel4;
    [SerializeField] int asLevel5;    
    [SerializeField] int adLevel7;
    [SerializeField] int projecMoveSpeedLevel8;
    [SerializeField] int adLevel9;
    [SerializeField] int asLevel10;

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
                stats.AddDmg(adLevel1);
                break;
            case 2:
                stats.MinusAS(asLevel2);
                break;
            case 3:
                stats.ActiveDiagonalArrows();
                break;
            case 4:
                stats.AddProjMoveSpeed(projecMoveSpeedLevel4);
                break;
            case 5:
                stats.MinusAS(asLevel5);
                break;
            case 6:
                stats.ActiveSideArrows();
                break;
            case 7:
                stats.AddDmg(adLevel7);
                break;
            case 8:
                stats.AddProjMoveSpeed(projecMoveSpeedLevel8);
                break;
            case 9:
                stats.AddDmg(adLevel9);
                break;
            case 10:
                stats.MinusAS(asLevel10);
                break;
        }
    }
}
