using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class Timer : MonoBehaviour
{
    // params
    public float levelTime = 0;
    public TimeSpan timeSpan;
    public bool activeTimer;

    // references
    [SerializeField] private TextMeshProUGUI timerText;


    // singleton
    public static Timer Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }


    void Update()
    {
        if (activeTimer)
        {
            levelTime -= Time.deltaTime;
            timeSpan = TimeSpan.FromSeconds(levelTime);
            timerText.text = String.Concat(timeSpan.Minutes,
                ":", timeSpan.Seconds);
            
            if (levelTime <= 0)
            {
                levelTime = 0;
                activeTimer = false;
            }
        }
    }


}
