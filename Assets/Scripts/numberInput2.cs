using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class numberInput2 : MonoBehaviour
{

    public static Transform[] inputs2;

    int row = 0;
    int column = 0;
    void Awake()
    {
        inputs2 = new Transform[transform.childCount];

        for (int i = 0; i < inputs2.Length; i++)
        {
            inputs2[i] = transform.GetChild(i);
            Text text = inputs2[i].GetComponentsInChildren<Text>()[0];
            inputs2[i].GetComponent<Menu>().Location = row * 10 + column;

            if (map.easy[row, column] == 0)
            {
                text.text = "";
                inputs2[i].GetComponent<Menu>().value = 0;
                inputs2[i].GetComponent<Menu>().changable = true;
                inputs2[i].GetComponent<Image>().color = new Color(0, 1, 0, 0.5f);
            }
            else
            {
                text.text = map.easy[row, column].ToString();
                inputs2[i].GetComponent<Menu>().value = map.easy[row, column];
                inputs2[i].GetComponent<Menu>().changable = false;
            }

            column++;
            if (column >= 9)
            {
                column = 0;
                row++;
            }
        }
    }
}
