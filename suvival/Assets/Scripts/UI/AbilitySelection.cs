using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySelection : MonoBehaviour
{
    public AbilitySlot[] abilitySlots;

    public static AbilitySelection Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void SetAbilitySlotss(Ability[] abilities)
    {
        for (int i = 0; i < 3; i++)
        {
            abilitySlots[i].SetAbilitySlot(abilities[i]);
        }
    }


}
