using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ObstacleCollision
{
    private LayerMask layerMask;
    private Transform transform;

    public ObstacleCollision(Transform transform)
    {
        this.transform = transform;
        layerMask = LayerMask.GetMask("Obstacle");
    }

    public bool IsHit
    {
        get
        {
            var center = new Vector3(transform.position.x.RoundToEven(), transform.position.y, transform.position.z);
            return !Physics.BoxCast(center, Vector3.one, transform.forward, transform.rotation, GlobalScale.scale, layerMask);
        }
    }
}
