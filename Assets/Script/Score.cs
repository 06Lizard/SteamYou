using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    int score = 0;
    int killPoints = 10;
    public TMP_Text scoreText;
    
    void Start()
    {
        scoreText.text = "Score: " + (score * 100).ToString();
    }

    //Removes one point from the score
    public void timeScoreUpdate()
    {
        score--;
        TextUpdate();
    }

    //Adds some points to the score
    public void enemyScoreUpdate()
    {
        score += killPoints;
        TextUpdate();
    }

    //Updates the text to show the correct score
    public void TextUpdate()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
