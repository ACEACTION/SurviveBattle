using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Lightning")]
public class Lightning : Ability
{
    public override void DoActive()
    {
        Debug.Log("Lightning");
    }
}
