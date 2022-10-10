using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    public List<GameObject> enemiesList = new List<GameObject>();


    //methods
    public void AddToList(GameObject obj)
    {
        enemiesList.Add(obj);
    }

    public void RemoveFromList(GameObject obj)
    {
        enemiesList.Remove(obj);
    }
}
