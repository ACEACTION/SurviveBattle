using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityUIManager : MonoBehaviour
{
    [SerializeField] List<Ability> abilities;
    List<Ability> abilitiesList = new List<Ability>();
    [SerializeField] AbilitySelection abilitySelection;
    Ability[] findedAbilitiesList = new Ability[3];
    int findedListIndex = 0;

    public static AbilityUIManager Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.J))
            OpenAbilityPanel();
    }

    public void OpenAbilityPanel()
    {
        DynamicJoystick.Instance.gameObject.SetActive(false);
        abilitySelection.gameObject.SetActive(true);
        abilitySelection.SetAbilitySlots(FindAbility());
        Time.timeScale = 0;
    }

    public void CloseAbilityPanel()
    {
        DynamicJoystick.Instance.gameObject.SetActive(true);
        abilitySelection.gameObject.SetActive(false);
        Time.timeScale = 1;
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
