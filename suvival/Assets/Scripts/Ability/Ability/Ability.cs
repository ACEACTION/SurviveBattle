using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ability : ScriptableObject
{
    public string abilityName;
    public int maxAbilityLevel;
    public int abilityLevel;
    public Sprite abilityIcon;
    public bool abilityIsDeactive;
    [HideInInspector] public string abilityDesc;
    [TextArea] public string[] abilityLevelsDesc;

    public virtual void DoActive() 
    {
        if (abilityIsDeactive)
            return;

        abilityDesc = abilityLevelsDesc[abilityLevel];
        abilityLevel++;

        if (abilityLevel > maxAbilityLevel)
            abilityIsDeactive = true;

    }

    public virtual void ResetAbility()
    {
        abilityLevel = 0;
        abilityIsDeactive = false;
    }

}

