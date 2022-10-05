using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MeteorArea : MonoBehaviour
{
    Action<GameObject> ReleaseMeteorArea;    
    IEnumerator Start()
    {
        yield return new WaitForSeconds(2f);
        ReleaseMeteorArea(gameObject);
    }
    

    public void InitAction(Action<GameObject> action)
    {
        ReleaseMeteorArea = action;
    }

}
