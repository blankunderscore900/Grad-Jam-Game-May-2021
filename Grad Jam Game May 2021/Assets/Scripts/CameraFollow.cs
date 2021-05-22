using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;

    public float smoothSpeed = 0.125f;

    public float offset;

    void LateUpdate()
    {
        Vector3 desiredPosition = transform.position;

        desiredPosition.x = target.position.x;

        desiredPosition.y = target.position.y;

        desiredPosition.y += offset;

        transform.position = desiredPosition;
    }
}
