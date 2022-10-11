using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XpSlider : MonoBehaviour
{
    public int xpValue;
    public static XpSlider Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;            
    }

    public void SetSlider(int xp)
    {
        xpValue = xp;
    }

}
