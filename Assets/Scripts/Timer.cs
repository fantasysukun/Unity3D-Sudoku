using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public static float timer = 1 * 60;
    string minutes;
    string seconds;
    float OneSecond = 1;
    public static bool runout = false;
    public static string result;

    Text text;

    void Awake()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        OneSecond -= Time.deltaTime;
        if (OneSecond <= 0.00)
        {
            timer -= 1;
            OneSecond = 1;
        }

        minutes = Mathf.Floor(timer / 60).ToString("00");
        seconds = (timer % 60).ToString("00");
        text.text = minutes + ":" + seconds;

        if (timer <= 0)
        {

            SetDefutTimer(1);
            runout = true;
            if (Score1.score > Score2.score)
            {
                result = "Player1 Wins";
            }
            else
            {
                result = "Player2 Wins";
            }
            SceneManager.LoadScene(3);
        }

    }

    public void SetDefutTimer(float Minutes)
    {
        timer = Minutes * 60;
    }
}
