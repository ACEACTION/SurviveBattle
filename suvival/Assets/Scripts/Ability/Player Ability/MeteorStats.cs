using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

[CreateAssetMenu(menuName = "MeteorStats")]
public class MeteorStats : ScriptableObject
{
    public float meteorMoveSpeed;
    public float meteorMoveDirOffsetScale;
    public GameObject meteorAreaPrefab;
    public ObjectPool<GameObject> meteorAreaPool;
    [SerializeField] float defaultMeteorAreaScale;
    public float meteorAreaScale;
    [SerializeField] int defaultMeteorCounter;
    public int meteorCounter;
    [SerializeField] float defaultMaxMakeMeteorCd;
    public float maxMakeMeteorCd;

    private void OnEnable()
    {
        meteorAreaPool = new ObjectPool<GameObject>(CreateMeteorArea, OnGet, OnRelease, OnDestoryMeteorArea, false, 100, 100000);        
    }

    #region object pool
    private void OnDestoryMeteorArea(GameObject obj)
    {
        Destroy(obj);
    }

    private void OnRelease(GameObject obj)
    {
        obj.SetActive(false);
    }

    private void OnGet(GameObject obj)
    {
        obj.SetActive(true);
    }

    private GameObject CreateMeteorArea()
    {
        GameObject meteor = Instantiate(meteorAreaPrefab, Vector3.zero, Quaternion.identity);
        return meteor;
    }

    public void OnReleaseMeteorArea(GameObject meteor)
    {
        meteorAreaPool.Release(meteor);
    }

    #endregion

    public void ResetMeteorAreaStats()
    {
        meteorAreaScale = defaultMeteorAreaScale;
        meteorCounter = defaultMeteorCounter;
        maxMakeMeteorCd = defaultMaxMakeMeteorCd;
    }
    
    public void AddMeteorAreaScale(float amount)
    {
        meteorAreaScale += amount;
    }

    public void AddMeteorCounter(int amount)
    {
        meteorCounter = amount;
    }

    public void MinusMakeMeteorCd(float amount)
    {
        maxMakeMeteorCd -= amount;
    }

}
