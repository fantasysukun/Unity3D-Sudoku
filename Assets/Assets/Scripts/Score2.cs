﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score2 : MonoBehaviour
{

    public static int score;
    Text text;

    void Awake()
    {
        text = GetComponent<Text>();
        score = 0;
    }

    void Update()
    {
        text.text = "" + score;
    }
}
