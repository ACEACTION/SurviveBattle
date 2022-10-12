using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinLosePanel : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] TextMeshProUGUI winLoseTxt;
    [SerializeField] GameObject winIcon;
    [SerializeField] GameObject loseIcon;

    public static WinLosePanel Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void WinProcess()
    {
        ActivePanel(true);
        loseIcon.SetActive(false);
        winIcon.SetActive(true);
        winLoseTxt.text = "Win";
    }

    public void LoseProcess()
    {
        ActivePanel(true);
        loseIcon.SetActive(true);
        winIcon.SetActive(false);
        winLoseTxt.text = "Lose";
    }
    public void ActivePanel(bool activation)
    {
        panel.SetActive(activation);
    }

}
