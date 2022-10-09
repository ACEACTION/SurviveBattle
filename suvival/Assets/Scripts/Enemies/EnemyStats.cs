using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;
[CreateAssetMenu(menuName = "EnemyStats")]
public class EnemyStats : ScriptableObject
{
    public float hp;
    public float movespeed;
    [SerializeField] GameObject lootEffectPrefab;



}
