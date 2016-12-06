using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class numberInput : MonoBehaviour {

    public static Transform[] inputs;

    int row = 0;
    int column = 0;
    void Awake()
    {
        inputs = new Transform[transform.childCount];

        for (int i = 0; i < inputs.Length; i++)
        {
            inputs[i] = transform.GetChild(i);
            Text text = inputs[i].GetComponentsInChildren<Text>()[0];
            inputs[i].GetComponent<Menu>().Location = row * 10 + column;

            if (map.easy[row, column] == 0)
            {
                text.text = "";
            }
            else
            {
                text.text = map.easy[row, column].ToString();
            }
            
            column++;
            if ( column >=9)
            {
                column = 0;
                row++;
            }
        }
    }
}
