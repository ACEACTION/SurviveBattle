using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbility_Satellite : MonoBehaviour
{

    int satelliteCounter;
    [SerializeField] SatelliteCenter satelliteCenterPrefab;
    SatelliteCenter satelliteCenter;

    public delegate void PlayerSatelliteAbilityDel();
    public static PlayerSatelliteAbilityDel PlayerAbilitySatellite;

    private void Start()
    {
        PlayerAbilitySatellite = SatelliteProcess;
    }

    void SatelliteProcess()
    {
        if (satelliteCounter == 0)
        {
           satelliteCenter = Instantiate(satelliteCenterPrefab, transform.position, Quaternion.identity);                       
           satelliteCenter.player = transform;           
        }
        else if (satelliteCounter == 1)
        {
            satelliteCenter.ActiveLevel2();
        }
        satelliteCounter++;
    }

}
