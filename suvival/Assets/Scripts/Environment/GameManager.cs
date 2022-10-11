using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] int maxXp;
    [SerializeField] int xp;
    [SerializeField] int level;
    public List<GameObject> enemiesList = new List<GameObject>();
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
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
        this.xp = xp;
    }

}
