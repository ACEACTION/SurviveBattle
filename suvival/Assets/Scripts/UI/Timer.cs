using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class Timer : MonoBehaviour
{
    // params
    public float t = 0;
    TimeSpan timeSpan;
    private bool countTime = true;

    // references
    [SerializeField] private TextMeshProUGUI timerText;

    void Update()
    {
        if (countTime)
        {
            t += Time.deltaTime;
            timeSpan = TimeSpan.FromSeconds(t);
            timerText.text = timeSpan.Hours + ":" + timeSpan.Minutes
                + ":" + timeSpan.Seconds;
        }
    }


}
