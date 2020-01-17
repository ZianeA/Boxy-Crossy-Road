using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashAnimation : MonoBehaviour, IHitVehicle
{
    [SerializeField]
    private float animationSpeed = 2;

    private PlayerDie player;
    private SqueezeAnimation squeezeAnimation;
    private float minScale = 0.2f;

    private void Start()
    {
        player = GetComponent<PlayerDie>();
        squeezeAnimation = new SqueezeAnimation(transform);
    }

    public void CrashIntoVehicle()
    {
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        StartCoroutine(CrashingAnimation());
    }

    private IEnumerator CrashingAnimation()
    {
        while (!squeezeAnimation.HasAnimationCompleted)
        {
            squeezeAnimation.Animate(minScale, animationSpeed);
            yield return null;
        }

        yield return new WaitForSeconds(.25f);

        player.Die();
    }
}
