using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField]
    private PlayerController player;

    private Text scoreLabel;
    private int score = 0;

    private void Start()
    {
        scoreLabel = GetComponent<Text>();
        SetScoreLabelText();

        player.MovingForward += () =>
        {
            score++;
            SetScoreLabelText();
        };
    }

    private void SetScoreLabelText()
    {
        scoreLabel.text = score.ToString();
    }
}
