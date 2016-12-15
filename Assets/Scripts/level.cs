using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class level : MonoBehaviour
{
    public static bool easy = false;
    public static bool med = false;
    public static bool hard = false;
    string result = "";

    Text text;

    void Awake()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        if (easy == true)
        {
            result = "Easy";
            text.text = result + "";
        }
        else if (med == true)
        {
            text.text = "Medium";
        }
        else if (hard == true)
        {
            text.text = "Hard";
        }
    }

    public void isEasy()
    {
        easy = true;
    }
    public void isMed()
    {
        med = true;
    }
    public void isHard()
    {
        hard = true;
    }
}
