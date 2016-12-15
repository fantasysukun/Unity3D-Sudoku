using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BigMove1 : MonoBehaviour {

    public static int Power;
    Text text;

    void Awake()
    {
        text = GetComponent<Text>();
        Power = 1;
    }

    void Update()
    {
        text.text = "" + Power;
    }
}
