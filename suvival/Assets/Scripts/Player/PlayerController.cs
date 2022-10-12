using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //variables
    [SerializeField] float hp;
    public Transform[] spawnPoints;

    // player level up
    [SerializeField] ParticleSystem levelUpEffect;
    [SerializeField] Healthbar healthbar;
    public static PlayerController Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        levelUpEffect.Stop();
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;
        healthbar.MinusHp(damage);
        if(hp <= 0)
        {
            Died();
        }        
    }        

    void Died()
    {
        Destroy(this.gameObject);
    }


    public void PlayLevelUpEffect()
    {        
        levelUpEffect.Play();
    }

}
