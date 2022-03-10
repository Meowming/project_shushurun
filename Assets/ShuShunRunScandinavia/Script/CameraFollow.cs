using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform targetTransform;
    public Vector3 offset;

    void LateUpdate()
    {
        transform.position = targetTransform.position + offset;
    }
}
