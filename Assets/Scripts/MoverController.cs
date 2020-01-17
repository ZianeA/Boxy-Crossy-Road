using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MoverController : MonoBehaviour
{
    private Vector3 velocity;
    private float speed;

    public float Speed
    {
        get
        {
            return speed;
        }
        set
        {
            speed = value;
            SetVelocity();
            RotateToDirection();
        }
    }

    private void Start()
    {
        SetVelocity();
        RotateToDirection();
    }

    private void Update()
    {
        transform.Translate(velocity * Time.deltaTime, Space.World);
    }

    private void SetVelocity()
    {
        velocity = Speed * Vector3.right;
    }

    private void RotateToDirection()
    {
        transform.rotation = Quaternion.LookRotation(speed * Vector3.forward);
    }
}
