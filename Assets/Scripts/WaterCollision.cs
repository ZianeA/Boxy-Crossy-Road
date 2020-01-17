using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCollision
{
    private Transform transform;
    private float yPosition;
    private Vector3 halfExtents;
    private LayerMask layerMask;

    public WaterCollision(Transform transform)
    {
        this.transform = transform;
        yPosition = -0.5f;
        halfExtents = Vector3.one * 0.5f;
        layerMask = LayerMask.GetMask("WaterAndLog");
    }

    public void CheckCollision()
    {
        var boxCenter = new Vector3(transform.position.x, yPosition, transform.position.z);
        var colliders = Physics.OverlapBox(boxCenter, halfExtents, transform.rotation, layerMask);

        if (colliders.Length == 1)
        {
            var hitWater = transform.GetComponents<IHitWater>();

            foreach (var hit in hitWater)
            {
                hit.Drown();
            }
        }
    }
}
