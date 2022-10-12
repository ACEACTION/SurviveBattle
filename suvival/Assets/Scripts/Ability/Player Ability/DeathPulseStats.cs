using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

[CreateAssetMenu(menuName = "Stats/DeathPulseStats")]
public class DeathPulseStats : ScriptableObject
{
    public float DeathPulseMoveSpeed;
    public ObjectPool<GameObject> deathPulseHitEffectPool;
    public GameObject hitEffectPrefab;


    private void OnEnable()
    {
        deathPulseHitEffectPool = new ObjectPool<GameObject>(() =>
        {
            return Instantiate(hitEffectPrefab);
        }, hitEffect =>
        {
            hitEffect.gameObject.SetActive(true);
        }, hitEffect =>
        {
            hitEffect.gameObject.SetActive(false);
        }, hitEffect =>
        {
            Destroy(hitEffect.gameObject);
        }, false, 10, 20);

    }


    public void KillDeathPulseEffect(GameObject obj)
    {
        deathPulseHitEffectPool.Release(obj);
    }
}
