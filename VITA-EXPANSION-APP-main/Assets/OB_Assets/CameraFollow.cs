using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;      // The character to follow
    public float FollowSpeed = 2f; // How quickly the camera follows
    public float yOffset = 1f;    // Vertical offset for the camera

    private void LateUpdate()
    {
        if (target != null)
        {
            // Calculate the desired position
            Vector3 desiredPosition = new Vector3(target.position.x, target.position.y + yOffset, -10f);

            // Smoothly move the camera to the desired position
            transform.position = Vector3.Lerp(transform.position, desiredPosition, FollowSpeed * Time.deltaTime);
        }
        else
        {
            UnityEngine.Debug.LogError("CameraFollow: Target is not assigned!");
        }
    }
}


