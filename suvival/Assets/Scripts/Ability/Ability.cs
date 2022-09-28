using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ability : ScriptableObject
{
    public string abilityName;
    public int abilityLevel;
    public Sprite abilityIcon;
    [TextArea] public string abilityDesc;

    public virtual void DoActive() { }

    public void Reset()
    {
        abilityLevel = 1;
    }




}

