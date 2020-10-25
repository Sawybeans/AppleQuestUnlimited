using System.Collections;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerChar;
    public float smoothTime = 0.6f;

    Vector3 thisVelocity = Vector3.zero;

    void FixedUpdate()
    {
        Vector3 targetPosition = playerChar.TransformPoint(new Vector3(0, 0, -10f));

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref thisVelocity, smoothTime);
    }
}
