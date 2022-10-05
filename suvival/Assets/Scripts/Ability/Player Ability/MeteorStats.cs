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
    public float meteorAreaScale;
    public ObjectPool<GameObject> meteorAreaPool;

    void OnEnable()
    {
        meteorAreaPool = new ObjectPool<GameObject>(CreateMeteorArea, OnGet, OnRelease, OnDestoryMeteorArea, false, 100, 100000);
    }

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

}
