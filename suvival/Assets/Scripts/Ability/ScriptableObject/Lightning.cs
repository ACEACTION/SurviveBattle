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
public class Lightning : Ability
{
    [SerializeField] float dmgLevel2;
    [SerializeField] float cdLevel3;
    [SerializeField] float radiusLevel4;
    [SerializeField] int countLevel5;
    [SerializeField] float dmgLevel6;
    [SerializeField] float cdLevel7;
    [SerializeField] float radiusLevel8;
    [SerializeField] float countLevel9;
    [SerializeField] float dmgLevel10;


    public override void DoActive()
    {
        switch (abilityLevel)
        {
            case 1:

                break;
            case 2:

                break;
            case 3:

                break;
            case 4:

                break;
            case 5:

                break;
            case 6:

                break;
            case 7:

                break;
            case 8:

                break;
            case 9:

                break;
            case 10:

                break;

        }
    }
}
