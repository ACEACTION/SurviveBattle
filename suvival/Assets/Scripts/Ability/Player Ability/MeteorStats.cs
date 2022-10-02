using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MeteorStats")]
public class MeteorStats : ScriptableObject
{
    public float meteorMoveSpeed;
    public float meteorMoveDirOffsetScale;
    public GameObject meteorArea;
}
