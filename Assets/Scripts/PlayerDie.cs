using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDie : MonoBehaviour
{
    [SerializeField] private GameObject GameOverScreen;
    [SerializeField] private Transform playerHolder;

    public void Die()
    {
        transform.GetComponent<Collider>().enabled = false;
        transform.SetParent(playerHolder);
        GameOverScreen.SetActive(true);
    }
}
