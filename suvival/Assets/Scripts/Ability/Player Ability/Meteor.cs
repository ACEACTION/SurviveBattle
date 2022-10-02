using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Meteor : MonoBehaviour
{
    Vector3 moveDir;
    [SerializeField] MeteorStats meteorStats;

    private void Start()
    {
        GetMoveDir();
        transform.LookAt(moveDir);
        Move();

    }

    void GetMoveDir()
    {
        moveDir = new Vector3(
            Random.Range(-meteorStats.meteorMoveDirOffsetScale, meteorStats.meteorMoveDirOffsetScale),
            -10,
            Random.Range(-meteorStats.meteorMoveDirOffsetScale, meteorStats.meteorMoveDirOffsetScale));
    }

    void Move()
    {
        transform.DOMove(moveDir, meteorStats.meteorMoveSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Instantiate(meteorStats.meteorArea, transform.position, Quaternion.identity);
        }
    }

}
