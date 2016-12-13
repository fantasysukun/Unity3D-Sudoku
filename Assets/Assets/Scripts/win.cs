using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class win : MonoBehaviour
{

    public static string winner;
    Text text;

    void Awake()
    {
        text = GetComponent<Text>();
        winner = "";
    }

    void Update()
    {
        text.text = "" + winner;
    }
}
