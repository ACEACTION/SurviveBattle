using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityPanel : MonoBehaviour
{
    [SerializeField] AbilitySlot[] slots;

    public void SetAbilitySlots(Ability[] abilities)
    {
        for (int i = 0; i < abilities.Length; i++)
        {
            slots[i].SetSlotsInfo(abilities[i]);
        }
    }
}
