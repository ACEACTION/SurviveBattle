using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasBillboard : MonoBehaviour
{
    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.transform.forward);
    }
}
