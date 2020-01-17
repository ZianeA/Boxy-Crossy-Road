using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        foreach (var item in other.GetComponents<IHitVehicle>())
        {
            item.CrashIntoVehicle();
        }
    }
}
