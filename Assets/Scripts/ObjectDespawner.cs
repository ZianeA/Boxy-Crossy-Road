using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDespawner : MonoBehaviour
{
    public static Transform DestructionPoint { get; set; }

    private WaitForSeconds wait = new WaitForSeconds(0.1f);

    private void OnEnable()
    {
        StartCoroutine(CheckVisibility());
    }

    private IEnumerator CheckVisibility()
    {
        yield return new WaitForEndOfFrame();

        while (true)
        {
            if (transform.position.z < DestructionPoint.position.z && gameObject.activeSelf)
            {
                gameObject.SetActive(false);
            }

            yield return wait;
        }
    }
}
