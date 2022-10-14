using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class PlayBtn : MonoBehaviour
{
    [SerializeField] GameObject timer;
    [SerializeField] GameObject gameplayCanvas;
    Button btn;

    public static PlayBtn Instance;
    private void Awake()
    {
        Time.timeScale = 0;
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(PlayButtonProcess);
    }

    public void PlayButtonProcess()
    {
        if (PlayerController.Instance.playerIsDead) return;

        GameManager.Instance.startGame = !GameManager.Instance.startGame;

        if (GameManager.Instance.startGame)
        {
            ClosePlayBtn();
        }
        else
        {
            OpenPlayBtn();
        }
    }

    public void ClosePlayBtn()
    {
        timer?.SetActive(true);
        Time.timeScale = 1.0f;
        gameplayCanvas?.SetActive(true);
        transform.DOLocalMoveY(-5000f, .7f);
    }

    public void OpenPlayBtn()
    {
        
        Time.timeScale = 1;
        gameplayCanvas?.SetActive(false);
        gameObject.SetActive(true);
        transform.DOLocalMoveY(0, .7f).OnComplete(() =>
        {
            Time.timeScale = 0;
        }); ;
    }


    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.O))
    //        OpenPlayBtn();
    //    if (Input.GetKeyDown(KeyCode.C))
    //        ClosePlayBtn();
    //}

}
