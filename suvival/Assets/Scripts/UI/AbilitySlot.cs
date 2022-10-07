using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class AbilitySlot : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI abilityName;
    [SerializeField] Image abilityIcon;
    [SerializeField] TextMeshProUGUI abilityDescription;
    public Button abilityButton;

    private void Awake()
    {
        abilityButton = GetComponent<Button>();
    }

    public void SetAbilitySlot(Ability ability)
    {
        abilityName.text = string.Concat(ability.abilityName, "\n", "lvl ", ability.abilityLevel + 1);
        abilityIcon.sprite = ability.abilityIcon;
        abilityDescription.text = ability.abilityDesc;
        abilityButton.onClick.RemoveAllListeners();
        abilityButton.onClick.AddListener(ability.DoActive);
        abilityButton.onClick.AddListener(ResetUI);

    }

    public void ResetUI()
    {
        DynamicJoystick.Instance.gameObject.SetActive(true);
        AbilitySelection.Instance.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

}
