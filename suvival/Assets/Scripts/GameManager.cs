using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> enemiesList = new List<GameObject>();


    //methods
    public void AddToList(GameObject gameobject)
    {
        enemiesList.Add(gameObject);
    }

    public void RemoveFromList(GameObject gameobject)
    {
        enemiesList.Remove(gameObject);
    }
}
