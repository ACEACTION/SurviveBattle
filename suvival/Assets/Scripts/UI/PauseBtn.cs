using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseBtn : MonoBehaviour
{
    [SerializeField] PlayBtn playBtn;
    [SerializeField] GameObject gameplayCanvas;
    Button pauseBtn;

    private void Start()
    {
        pauseBtn = GetComponent<Button>();
        pauseBtn.onClick.AddListener(Pause);
    }

    void Pause()
    {
        gameplayCanvas.SetActive(false);
        playBtn.PlayButtonProcess();
    }

}
