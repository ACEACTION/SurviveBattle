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
        abilitySelection.SetAbilitySlotss(abilities);     
        Time.timeScale = 0;
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
