using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

[CreateAssetMenu(menuName = "Stats/MeteorStats")]
public class MeteorStats : ScriptableObject
{
    public float meteorMoveSpeed;
    public float meteorMoveDirOffsetScale;
    public float radius;
    [SerializeField] float defaultRadius;
    public int counter;
    [SerializeField] int defaultCounter;
    public float maxCd;
    [SerializeField] public float defaultMaxCd;
    public float dmg;
    [SerializeField] public float defaultDmg;

    public GameObject meteorAreaPrefab;
    public ObjectPool<GameObject> meteorAreaPool;

    void OnEnable()
    {
        meteorAreaPool = new ObjectPool<GameObject>(CreateMeteorArea, OnGet, OnRelease, OnDestoryMeteorArea, false, 100, 100000);
    }

    public void ResetStats()
    {
        radius = defaultRadius;
        counter = defaultCounter;
        maxCd = defaultMaxCd;
    }

    public void SetCounter(int c)
    {
        counter = c;
    }

    public void AddRadius(float r)
    {
        radius += r;
    }

    public void MinusCd(float cd)
    {
        maxCd -= cd;
    }

    public void AddDmg(int d)
    {
        dmg += d;
    }

    #region pool object
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



}
