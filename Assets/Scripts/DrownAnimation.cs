using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrownAnimation : MonoBehaviour, IHitWater
{
    private PlayerDie player;

    private void Start()
    {
        player = GetComponent<PlayerDie>();
    }

    public void Drown()
    {
        StartCoroutine(DrowningAnimation());
    }

    private IEnumerator DrowningAnimation()
    {
        while (transform.position.y > -2)
        {
            transform.position += Vector3.down * Time.deltaTime * 4;
            yield return null;
        }

        player.Die();
    }
}
