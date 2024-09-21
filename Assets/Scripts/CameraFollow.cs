using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public Vector3 offset; // Offset from the player's position

    private void LateUpdate()
    {
        if (player != null)
        {
            // Update the camera's position based on the player's position and the offset
            transform.position = player.position + offset;
        }
    }
}
