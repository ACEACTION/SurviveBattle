using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int maxXp = 100;
    public int xp;
    public int level = 1;
    public bool startGame;
    public List<GameObject> enemiesList = new List<GameObject>();
    public static GameManager Instance;
    [SerializeField] EnemyStats orcStats;
    [SerializeField] EnemyStats ghostStats;


    private void Awake()
    {
        Application.targetFrameRate = 60;
        if (Instance == null)
            Instance = this;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) AddXp(20);
    }

    //methods
    public void AddToList(GameObject obj)
    {
        enemiesList.Add(obj);
    }

    public void RemoveFromList(GameObject obj)
    {
        enemiesList.Remove(obj);
    }

    public void AddXp(int xp)
    {
        this.xp += xp;
        XpSlider.Instance.SetSliderValue();
        CheckLevel();
    }

    public void CheckLevel()
    {
        if (xp >= maxXp)
        {
            level++;
            xp = 0;
            XpSlider.Instance.SetLevelTxt();
            XpSlider.Instance.ResetSlider();
            SetMaxXp();

            if (level <= 30)
            {
                AbilityUIManager.Instance.OpenAbilityPanel();
                PlayerController.Instance.PlayLevelUpEffect();
            }
        }
    }

    void SetMaxXp()
    {
        switch (level)
        {
            case 2:
                maxXp = 120;
                break;
            case 3:
                maxXp = 200;
                break;
            case 4:
                maxXp = 320;
                break;
            case 5:
                maxXp = 460;
                break;
            case 6:
                maxXp = 620;
                break;
            case 7:
                maxXp = 820;
                break;
            case 8:
                maxXp = 1000;
                break;
            case 9:
                maxXp = 1100;

                break;
            case 10:
                maxXp = 1120;

                break;
            case 11:
                maxXp = 1200;
                break;
            case 12:
                maxXp = 1210;
                break;
            case 13:
                maxXp = 1220;
                break;
            case 14:
                maxXp = 1260;
                break;
            case 15:
                maxXp = 1300;
                break;
            case 16:
                maxXp = 1310;
                break;
            case 17:
                maxXp = 1320;
                break;
            case 18:
                maxXp = 1330;
                break;
            case 19:
                maxXp = 1335;
                break;
            case 20:
                maxXp = 1340;
                break;
            case 21:
                maxXp = 1345;
                break;
            case 22:
                maxXp = 1350;
                break;
            case 23:
                maxXp = 1380;
                break;
            case 24:
                maxXp = 1450;
                break;
            case 25:
                maxXp = 1460;
                break;
            case 26:
                maxXp = 1480;
                break;
            case 27:
                maxXp = 1520;
                break;
            case 28:
                maxXp = 1530;
                break;
            case 29:
                maxXp = 1530;
                break;
            case 30:
                maxXp = 1530;
                break;
        }
        
        XpSlider.Instance.SetSliderMaxValue();
    }


    private void OnDisable()
    {
        orcStats.ResetStats();
        ghostStats.ResetStats();
    }

}
