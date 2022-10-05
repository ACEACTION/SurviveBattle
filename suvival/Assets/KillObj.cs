using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillObj : MonoBehaviour
{
    
    void Start()
    {
        Destroy(gameObject, 2);
    }

}
