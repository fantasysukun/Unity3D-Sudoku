using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class winner : MonoBehaviour
{

    Text text;

    void Awake()
    {
        text = GetComponent<Text>();
    }


    // Update is called once per frame
    void Update()
    {
        //string result = ConditionCheching.result;
        string result = ConditionCheching.WinningConditionChecking(numbercontroller.Current9X9Grid);
        //text.text = result;
        if (Timer.runout == true)
        {
            text.text = Timer.result;
        }
        else if (result == "Player1")
        {
            text.text = "Player1 Wins!";
        }

        else
        {
            text.text = "Player2 Wins!";
        }
        //if (ConditionCheching.result == "Player2")
        //{
        //    text.text = "Player2 Wins!";
        //}
        //text.text = "Player1 Wins!";
    }

}
