using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityUIManager : MonoBehaviour
{
    [SerializeField] Ability[] abilities;
    [SerializeField] AbilitySelection abilitySelection;
    

    private void Start()
    {
        
    }


    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.J))
            SetAbility();
    }

    public void SetAbility()
    {
        DynamicJoystick.Instance.gameObject.SetActive(false);
        abilitySelection.gameObject.SetActive(true);
        abilitySelection.SetAbilitySlotss(FindAbility());
        Time.timeScale = 0;
    }

    Ability[] FindAbility()
    {
        int index = 0;
        Ability[] findedAbilities = new Ability[3];

        while (index < 3)
        {
            Ability ability = abilities[Random.Range(0, abilities.Length)];
            if (!ability.abilityIsDeactive)
            {
                findedAbilities[index] = ability;
                index++;
            }
        }
        return findedAbilities;
    }

    private void OnDisable()
    {
        // reset abilities
        for (int i = 0; i < abilities.Length; i++)
        {
            abilities[i].ResetAbility();
        }
    }


}
