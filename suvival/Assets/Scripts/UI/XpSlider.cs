using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class XpSlider : MonoBehaviour
{
    public int xpValue;
    [SerializeField] TextMeshProUGUI xpTxt;
    [SerializeField] TextMeshProUGUI startLevelTxt;
    [SerializeField] TextMeshProUGUI endLevelTxt;
    public static XpSlider Instance;
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;            
    }

    public void SetSlider(int xp)
    {
        xpValue += xp;
    }

    public void SetLevelTxt()
    {
        
    }

}
