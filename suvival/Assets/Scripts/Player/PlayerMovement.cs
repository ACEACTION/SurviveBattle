using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] DynamicJoystick joystick;
    [SerializeField] float rotateSpeed;
    public float moveSpeed;
    [SerializeField] Animator anim;
    public Vector3 movementDir;
    public float xDir, zDir;

    public static PlayerMovement Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }


    void Update()
    {     
        Move();
        RotatePlayerFace();
        SetAnimationMove();
     
    }

    private void Move()
    {
        xDir = joystick.Horizontal;
        zDir = joystick.Vertical;

        movementDir.Set(xDir, 0, zDir);
        transform.position += movementDir * Time.deltaTime * moveSpeed;
    }

    public void RotatePlayerFace()
    {
        if (PlayerIsMoving())
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movementDir), Time.deltaTime * rotateSpeed);
    }

    void SetAnimationMove()
    {
        if (PlayerIsMoving())
        {
            anim.SetBool("Running", true);
            anim.SetBool("Attacking", false);
        }
        else
            anim.SetBool("Running", false);
    }

    public void ResetMovement()
    {
        movementDir = Vector3.zero;
        xDir = 0;
        zDir = 0;        
    }

    public bool PlayerIsMoving()
    {
        return movementDir != Vector3.zero;
    }
}
