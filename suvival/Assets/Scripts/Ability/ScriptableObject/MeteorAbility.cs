using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Meteor Ability")]
public class MeteorAbility : Ability
{
    [SerializeField] MeteorStats meteorStats;
    public List<int> meteroCountList = new List<int>();
    public List<float> meteorAreaList = new List<float>();

    public override void DoActive()
    {
        if (abilityLevel == 2)
        {
            abilityDesc = abilityLevelsDesc[0];
        }
    }
}
