using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFallow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, smoothSpeed);
    }
}
