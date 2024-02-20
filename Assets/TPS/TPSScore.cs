using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TPSScore : MonoBehaviour
{

    [SerializeField]
    public TMP_Text scoreText;

    int score = 0;

    public void AddScore()
    {
        score++;
        scoreText.text = "Score: " + score;
    }
}
