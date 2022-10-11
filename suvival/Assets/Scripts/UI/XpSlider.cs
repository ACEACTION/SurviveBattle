using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class XpSlider : MonoBehaviour
{
    [SerializeField] Slider xpSlider;
    [SerializeField] TextMeshProUGUI xpTxt;
    [SerializeField] TextMeshProUGUI startLevelTxt;
    [SerializeField] TextMeshProUGUI endLevelTxt;
    public static XpSlider Instance;
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;            
    }

    private void Start()
    {
        SetSliderMaxValue();
        SetLevelTxt();
    }

    public void SetSliderValue()
    {        
        xpSlider.value = GameManager.Instance.xp;
        xpTxt.text = GameManager.Instance.xp.ToString();
    }

    public void SetLevelTxt()
    {
        startLevelTxt.text = GameManager.Instance.level.ToString();
        endLevelTxt.text = (GameManager.Instance.level+1).ToString();
    }

    public void ResetSlider()
    {
        xpSlider.value = 0;
        xpTxt.text = "0";
    }

    public void SetSliderMaxValue()
    {
        xpSlider.maxValue = GameManager.Instance.maxXp;
    }

}
