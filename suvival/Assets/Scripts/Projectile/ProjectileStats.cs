using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ProjectileStats")]
public class ProjectileStats : ScriptableObject
{
    public float damage;
    public float damageDefault;

    public float projecMoveSpeed;
    public float projecMoveSpeedDefault;

    public float attackCdAmount;
    public float defaultAttackCdAmount;

    public bool sidedArrows;
    public bool diagonalArrows;

    public float projectileDestroyTime;
    public  void ResetStats()
    {
        damage = damageDefault;
        projecMoveSpeed = projecMoveSpeedDefault;
        attackCdAmount = defaultAttackCdAmount;
        sidedArrows = false;
        diagonalArrows = false;
    }

    public void AddDmg(int d)
    {
        damage += d;
    }

    public void AddProjMoveSpeed(int ms)
    {
        projecMoveSpeed += ms;
    }

    public void MinusAS(float cd)
    {
        attackCdAmount -= cd;
    }

    public void ActiveSideArrows()
    {
        sidedArrows = true;
    }

    public void ActiveDiagonalArrows()
    {
        diagonalArrows = true;
    }


}
