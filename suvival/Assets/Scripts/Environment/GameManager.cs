using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int maxXp;
    public int xp;
    public int level = 1;
    public bool startGame;
    public List<GameObject> enemiesList = new List<GameObject>();
    public static GameManager Instance;

    [SerializeField] EnemyStats orcStats;
    [SerializeField] EnemyStats ghostStats;


    private void Awake()
    {
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

                break;
            case 3:

                break;
            case 4:

                break;
            case 5:

                break;
            case 6:

                break;
            case 7:

                break;
            case 8:

                break;
            case 9:

                break;
            case 10:

                break;
            case 11:

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
