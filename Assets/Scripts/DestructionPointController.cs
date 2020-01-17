using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class DestructionPointController : MonoBehaviour
{
    private Camera mainCamera;
    private Vector3 offset;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += (arg0, arg1) => mainCamera = Camera.main;
    }

    private void Start()
    {
        transform.position = new Vector3(0, 0, -18);

        mainCamera = Camera.main;
        offset = transform.position - mainCamera.transform.position;
        DontDestroyOnLoad(gameObject);
    }

    private void LateUpdate()
    {
        transform.position = mainCamera.transform.position + offset;
    }
}
