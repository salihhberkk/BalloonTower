using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraMovement : MonoSingleton<CameraMovement>
{
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 offset;

    [SerializeField] private float smoothSpeed = 0.125f;

    void FixedUpdate()
    {
        Vector3 desiredPos = player.transform.position + offset;
        Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed);

        transform.position = smoothedPos;
    }
    public void SetOffset()
    {
        offset.z -= 0.5f;
    }
}