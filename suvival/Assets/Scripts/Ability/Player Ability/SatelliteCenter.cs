using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatelliteCenter : MonoBehaviour
{
    [SerializeField] Vector3 posOffset;
    [HideInInspector] public Transform player;
    [SerializeField] Transform[] level1Satellites;
    [SerializeField] Transform[] level2Satellites;
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.position = player.position + posOffset;
    }

    public void ActiveLevel2()
    {
        for (int i = 0; i < level1Satellites.Length; i++)
        {
            level1Satellites[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < level2Satellites.Length; i++)
        {
            level2Satellites[i].gameObject.SetActive(true);
        }
    }

}
