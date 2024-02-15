using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    public float time = 0;
    int lastValue = 0;
    public int timePoints;
    public PlayerStats playerStats;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if ((int)time > lastValue)
        {
            playerStats.AddToScore(timePoints);
            lastValue++;
        }
    }
}
