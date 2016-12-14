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
        string result = ConditionCheching.result;
        if (ConditionCheching.result == "Player1")
        {
            text.text = "Player1 Wins!";
        }
        if (ConditionCheching.result == "Player2")
        {
            text.text = "Player2 Wins!";
        }
        //text.text = "Player1 Wins!";
    }

}
