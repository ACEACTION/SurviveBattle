using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityUIManager : MonoBehaviour
{
    [SerializeField] List<Ability> abilities;
    [SerializeField] List<Ability> abilitiesList;
    [SerializeField] AbilitySelection abilitySelection;
    [SerializeField] Ability[] findedAbilitiesList = new Ability[3];
    int findedListIndex = 0;
    

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
        SetAbilitiesItemList();

        while (findedListIndex < 3)
        {
            Ability ability = abilitiesList[Random.Range(0, abilitiesList.Count)];
            if (!ability.abilityIsDeactive)
            {
                findedAbilitiesList[findedListIndex] = ability;
                abilitiesList.Remove(ability);
                findedListIndex++;
            }
        }

        return findedAbilitiesList;
    }


    void SetAbilitiesItemList()
    {
        abilitiesList.Clear();
        for (int i = 0; i < abilities.Count; i++)
        {
            abilitiesList.Add(abilities[i]);
        }
    }

    private void OnDisable()
    {
        // reset abilities
        for (int i = 0; i < abilities.Count; i++)
        {
            abilities[i].ResetAbility();
        }
    }


}
