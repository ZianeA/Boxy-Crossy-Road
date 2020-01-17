using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverDespawner : MonoBehaviour
{
    [SerializeField]
    private Renderer bodyRenderer;

    private bool isVisible;
    private WaitForSeconds wait = new WaitForSeconds(0.25f);

    private void OnEnable()
    {
        isVisible = false;
        StartCoroutine(CheckVisibility());
    }

    private IEnumerator CheckVisibility()
    {
        while (true)
        {
            if (bodyRenderer.isVisible)
                isVisible = true;

            if (isVisible && !bodyRenderer.isVisible)
            {
                gameObject.SetActive(false);
            }

            yield return wait;
        }
    }
}
