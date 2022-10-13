using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityUIManager : MonoBehaviour
{
   [SerializeField] List<Ability> abilities;
   public List<Ability> abilitiesList = new List<Ability>();
   [SerializeField] AbilityPanel abilityPanel;
   public Ability[] findedAbilitiesList = new Ability[3];
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
        abilityPanel.gameObject.SetActive(true);
        abilityPanel.SetAbilitySlots(FindAbility());
        Time.timeScale = 0;
    }

    public void CloseAbilityPanel()
    {
        DynamicJoystick.Instance.gameObject.SetActive(true);
        abilityPanel.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    Ability[] FindAbility()
    {
        SetAbilitiesItemList();

        for (int i = 0; i < 3; i++)
        {
            Ability ability = abilitiesList[Random.Range(0, abilitiesList.Count)];
            findedAbilitiesList[i] = ability;
            abilitiesList.Remove(ability);            
        }
        
        return findedAbilitiesList;
    }


    void SetAbilitiesItemList()
    {
        abilitiesList.Clear();
        for (int i = 0; i < abilities.Count; i++)
        {
            if (!abilities[i].abilityIsDeactive)
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
