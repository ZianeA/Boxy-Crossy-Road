using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    private void Start()
    {
        ObjectPool.Reset();
    }

    private void Update()
    {
        if (!gameObject.activeSelf)
            return;

        if (Input.GetMouseButton(0))
            gameObject.SetActive(false);
    }
}
