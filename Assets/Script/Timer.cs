using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    float time = 0;
    public TMP_Text timerText;
    public Score score;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timerText.text = "Time: " + ((int)time).ToString();

        if (time % 5 == 0)
        {
            score.timeScoreUpdate();
        }         
    }
}
