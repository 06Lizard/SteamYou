using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    public float time = 0;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
    }
}
