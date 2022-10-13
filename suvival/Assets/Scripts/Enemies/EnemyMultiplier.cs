using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMultiplier : MonoBehaviour
{
    public float hpMultiplier = 10;
    public float hpMultiplierFactor;
    public float cdBetweenSpawnsMultiplier;
    public float cdBetweenSpawnsMultiplierFactor;
    [SerializeField] Timer timer;
    private void Start()
    {
    }

    private void Update()
    {
        SetHpMultiplier();
    }

    void SetHpMultiplier()
    {
        switch ((int)timer.levelTime)
        {            
            case 720:                
                hpMultiplierFactor = 2;                
                SetCdTimeBetweenSpawnMulitplier();
                break;
            case 540:
                hpMultiplierFactor = 4;
                SetCdTimeBetweenSpawnMulitplier();
                break;
            case 360:
                hpMultiplierFactor = 6;
                SetCdTimeBetweenSpawnMulitplier();
                break;
            case 180:
                hpMultiplierFactor = 8;
                SetCdTimeBetweenSpawnMulitplier();
                break;            
        }
    }

    public float GetHpMultiplier()
    {
        return hpMultiplier * hpMultiplierFactor;
    }

    public void SetCdTimeBetweenSpawnMulitplier()
    {
        cdBetweenSpawnsMultiplier -= cdBetweenSpawnsMultiplierFactor;
    }
}
