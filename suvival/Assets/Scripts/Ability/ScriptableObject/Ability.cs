using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ability : ScriptableObject
{
    [HideInInspector] public bool abilityIsDeactive;
    public string abilityName;
    public int maxAbilityLevel = 4;
    public int abilityLevel = 1;
    public Sprite abilityIcon;
    [HideInInspector] public string abilityDesc;
    [TextArea] public string[] abilityLevelsDesc;

    public virtual void DoActive() { }

    public void ResetUpgradeLevel()
    {
        abilityLevel = 0;
    }




}

