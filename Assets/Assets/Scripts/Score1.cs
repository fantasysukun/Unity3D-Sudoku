using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score1 : MonoBehaviour {

    public static int score;
    Text text;

    void Awake()
    {
        text = GetComponent<Text>();
        score = 10;
    }

    void Update()
    {
        text.text = "" + score;
    }
}
