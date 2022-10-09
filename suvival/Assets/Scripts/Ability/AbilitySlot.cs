using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AbilitySlot : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI abilityNameTxt;
    [SerializeField] TextMeshProUGUI abilityLevelTxt;
    [SerializeField] Image abilityIcon;
    [SerializeField] TextMeshProUGUI abilityDescText;
    Button abilityButton;

    private void Awake()
    {
        abilityButton = GetComponent<Button>();
    }

    public void SetSlotsInfo(Ability ability)
    {
        abilityNameTxt.text = ability.abilityName;
        abilityLevelTxt.text = ability.abilityLevel.ToString();
        abilityIcon.sprite = ability.abilityIcon;
        abilityDescText.text = ability.abilityDesc;
        
        ButtonProcess(ability);
    }

    private void ButtonProcess(Ability ability)
    {
        abilityButton.onClick.RemoveAllListeners();
        abilityButton.onClick.AddListener(ability.DoActive);
        abilityButton.onClick.AddListener(AbilityUIManager.Instance.CloseAbilityPanel);
    }



}
