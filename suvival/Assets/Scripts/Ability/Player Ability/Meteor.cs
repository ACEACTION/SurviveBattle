using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using Random = UnityEngine.Random;

public class Meteor : MonoBehaviour
{
    Vector3 moveDir;
    [SerializeField] MeteorStats meteorStats;
    Action<GameObject> ReleaseMeteor;
    public bool isGrounded;

    public void InitMeteor(Action<GameObject> action)
    {
        GetMoveDir();
        transform.LookAt(moveDir);
        isGrounded = false;
        ReleaseMeteor = action;
    }

    void GetMoveDir()
    {
        moveDir = new Vector3(
            Random.Range(transform.position.x - meteorStats.meteorMoveDirOffsetScale,
            transform.position.x + meteorStats.meteorMoveDirOffsetScale),
            2,
            Random.Range(transform.position.z - meteorStats.meteorMoveDirOffsetScale,
                transform.position.z + meteorStats.meteorMoveDirOffsetScale));
    }

    private void Update()
    {
        Move();

        if (Vector3.Distance(transform.position, moveDir) <= 1f && !isGrounded)
        {
            MakeMeteorArea();
            isGrounded = true;
            AudioSourceController.Instance.PlayMeteorSfx();
            ReleaseMeteor(gameObject);
        }
    }

    private void MakeMeteorArea()
    {
        MeteorArea meteorArea = meteorStats.meteorAreaPool.Get().GetComponent<MeteorArea>();
        meteorArea.transform.position = transform.position;
        meteorArea.InitAction(meteorStats.OnReleaseMeteorArea, meteorStats.dmg);
        meteorArea.transform.localScale = new Vector3(
                meteorStats.radius, meteorStats.radius, meteorStats.radius);

    }

    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, moveDir,
            meteorStats.meteorMoveSpeed * Time.deltaTime);


    }





}
