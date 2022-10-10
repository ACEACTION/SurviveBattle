using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ProjectileStats")]
public class ProjectileStats : ScriptableObject
{
    public float damage;
    public float damageDefault;

    public float moveSpeed;
    public float moveSpeedDefault;

    public float attackCd;
    public float attackCdAmount;

    public bool sidedArrows;
    public bool sidedArrowsDefault = false;

    public bool diagonalArrows;
    public bool diagonalArrowsDefault = false;


}
