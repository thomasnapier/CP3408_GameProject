﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour
{

    public static int sec;
    public static int min;
    public static float timer;
    

    TextMeshProUGUI timeText;

    void Awake()
    {
        timeText = GetComponent<TextMeshProUGUI>();
        sec = 0;
        min = 0;
        timer = 3600;
    }

    void Update()
    {
        timer += Time.deltaTime;
        sec = (int)(timer % 60);
        min = (int)(timer / 60);
        timeText.text = min + ":" + sec;
    }
}
