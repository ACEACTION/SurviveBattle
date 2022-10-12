using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBloodSplat : MonoBehaviour
{
    Sprite bloodSprite;
    [SerializeField] Image bloodImg;
    Action<GameObject> _KillAction;
    [SerializeField] float destroyTimer = 2f;

    private void Start()
    {
        SetBloodImage();
    }

    private void Update()
    {
        if (destroyTimer <= 0)
        {
            destroyTimer = 2f;
            _KillAction(gameObject);
        }
        else
        {
            destroyTimer -= Time.deltaTime;
        }
    }
    
    public void SetBloodImage()
    {
        bloodImg.sprite = bloodSprite;
    }

    public void Init(Action<GameObject> action, Sprite bloodSprite)
    {
        _KillAction = action;
        bloodImg.sprite = bloodSprite;
        this.bloodSprite = bloodSprite;
    }



}
