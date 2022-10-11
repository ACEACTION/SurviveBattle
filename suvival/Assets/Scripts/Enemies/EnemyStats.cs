using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;
[CreateAssetMenu(menuName = "EnemyStats")]
public class EnemyStats : ScriptableObject
{
    public float hp;
    public float hpDefault;

    public float damage;
    public float damageDefault;

    public float movespeed;
    public int xpAmount;
       
    public ObjectPool<GameObject> lootEffectPool;
    public GameObject lootEffectPrefab;
    public ObjectPool<GameObject> enemyBloodPool;
    public Sprite[] enemyBloodSprites;
    public GameObject enemyBloodPrefab;


    private void OnEnable()
    {
        //loot effect
        lootEffectPool = new ObjectPool<GameObject>(() =>
        {
            return Instantiate(lootEffectPrefab);
        }, lootEffect =>
        {
            lootEffect.gameObject.SetActive(true);
        }, lootEffect =>
        {
            lootEffect.gameObject.SetActive(false);
        }, lootEffect =>
        {
            Destroy(lootEffect.gameObject);
        }, false, 10, 20);


        //death effect
        enemyBloodPool = new ObjectPool<GameObject>(() =>
        {
            return Instantiate(enemyBloodPrefab);
        }, deathEffect =>
        {
            deathEffect.gameObject.SetActive(true);
        }, deathEffect =>
        {
            deathEffect.gameObject.SetActive(false);
        }, deathEffect =>
        {
            Destroy(deathEffect.gameObject);
        }, false, 10, 20);

    }


    public void KillLootEffect(GameObject obj)
    {
        lootEffectPool.Release(obj);
    }

    public void KillDeathEffect(GameObject obj)
    {
        enemyBloodPool.Release(obj);
    }



    public void AddXp(float xp)
    {
        PlayerShooting.instance.xp += xp;
    }
}
