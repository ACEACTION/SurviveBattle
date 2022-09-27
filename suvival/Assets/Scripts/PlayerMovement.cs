using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] DynamicJoystick joystick;
    [SerializeField] float rotateSpeed;
    public float moveSpeed;

    Vector3 movementDir;
    float xDir, zDir;

    void Update()
    {
        Move();
        RotatePlayerFace();
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
        if (movementDir != Vector3.zero)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movementDir), Time.deltaTime * rotateSpeed);
    }
}
