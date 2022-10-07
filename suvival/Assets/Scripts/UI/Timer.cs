using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{

    // params
    [Tooltip("Seconds")] [SerializeField] float levelTime = 0;
    TimeSpan timeSpan;    
    private bool countTime = true;

    // references
    [SerializeField] private TextMeshProUGUI timerText;
    


    void Update()
    {
        if (levelTime > 0)
        {
            levelTime -= Time.deltaTime;
            timeSpan = TimeSpan.FromSeconds(levelTime);
            timerText.text = String.Concat(timeSpan.Minutes, ":", timeSpan.Seconds);
        }
        else 
        { 
            // 
        }
    }


}