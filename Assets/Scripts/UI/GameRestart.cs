using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRestart : MonoBehaviour
{
    [SerializeField] private SceneTransition sceneTransition;

	public void Restart()
    {
        sceneTransition.FadeOut(SceneManager.GetActiveScene().buildIndex);
    }
}
