using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //variables
    [SerializeField] float playerHp;
    public Transform[] spawnPoints;
    public bool playerIsDead = false;

    // player level up
    [SerializeField] ParticleSystem levelUpEffect;
    [SerializeField] Healthbar healthbar;
    public static PlayerController Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        healthbar.SetHp(playerHp);
        levelUpEffect.Stop();

    }

    public void TakeDamage(float damage)
    {
        playerHp -= damage;
        healthbar.MinusHp(damage);
        if(playerHp <= 0)
        {
            Died();
        }        
    }        

    void Died()
    {
        playerIsDead = true;
        WinLosePanel.Instance.LoseProcess();
        AudioSourceController.Instance.PlayLoseSfx();
        Destroy(this.gameObject);
    }


    public void PlayLevelUpEffect()
    {        
        levelUpEffect.Play();
    }

}
