using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    private Vector3 offset;
    public float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;
    private float previousPlayerPosition;

    private void Start()
    {
        offset = transform.position - player.position;
    }

    private void LateUpdate()
    {
        Vector3 targetPosition;

        if (previousPlayerPosition < player.position.z)
        {
            targetPosition = new Vector3(player.position.x + offset.x, transform.position.y, player.position.z + offset.z);
            previousPlayerPosition = player.position.z;
        }
        else
        {
            targetPosition = new Vector3(player.position.x + offset.x, transform.position.y, transform.position.z);
        }

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }

}
