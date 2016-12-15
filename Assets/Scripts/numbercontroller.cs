using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class numbercontroller : MonoBehaviour
{

    public static Button selectedObject;
    public static Button selectedObject2;

    public Button firstObject;
    public Button firstObject2;
    public int position;
    public int position2;
    public int arrayPosition = 0;
    public int arrayPosition2 = 0;
    public static bool isOpen = false;
    public static bool isOpen2 = false;
    public static bool isFreeze = false;
    public static bool isFreeze2 = false;

    public static int[,] Current9X9Grid;
    public static int[,] Current9X9Grid2;

    // Use this for initialization
    void Start()
    {
        selectedObject = firstObject;
        Current9X9Grid = map.easy;
        position = selectedObject.GetComponent<Menu>().Location;
        selectedObject.image.color = new Color(255, 255, 255, 255);

        selectedObject2 = firstObject2;
        Current9X9Grid2 = map.easy;
        position2 = selectedObject2.GetComponent<Menu>().Location;
        selectedObject2.image.color = new Color(255, 255, 255, 255);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isFreeze)
        {
            if (!isOpen)
            {

                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    changeColor();

                    if (position % 10 > 0)
                    {
                        selectedObject = numberInput.inputs[arrayPosition - 1].GetComponent<Button>();
                        arrayPosition = arrayPosition - 1;
                        position = position - 1;
                    }
                    else
                    {
                        selectedObject = numberInput.inputs[arrayPosition + 8].GetComponent<Button>();
                        position = position + 8;
                        arrayPosition = arrayPosition + 8;
                    }
                    selectedObject.image.color = new Color(255, 255, 255, 255);

                }

                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    changeColor();
                    if (position % 10 < 8)
                    {
                        selectedObject = numberInput.inputs[arrayPosition + 1].GetComponent<Button>();
                        position = position + 1;
                        arrayPosition = arrayPosition + 1;
                    }
                    else
                    {
                        selectedObject = numberInput.inputs[arrayPosition - 8].GetComponent<Button>();
                        position = position - 8;
                        arrayPosition = arrayPosition - 8;
                    }

                    selectedObject.image.color = new Color(255, 255, 255, 255); ;
                }

                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    changeColor();

                    if (position / 10 > 0)
                    {
                        selectedObject = numberInput.inputs[arrayPosition - 9].GetComponent<Button>();
                        position = position - 10;
                        arrayPosition = arrayPosition - 9;
                    }
                    else
                    {
                        selectedObject = numberInput.inputs[arrayPosition + 72].GetComponent<Button>();
                        position = position + 80;
                        arrayPosition = arrayPosition + 72;
                    }
                    selectedObject.image.color = new Color(255, 255, 255, 255);
                }

                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    changeColor();

                    if (position / 10 < 8)
                    {
                        selectedObject = numberInput.inputs[arrayPosition + 9].GetComponent<Button>();
                        position = position + 10;
                        arrayPosition = arrayPosition + 9;
                    }
                    else
                    {
                        selectedObject = numberInput.inputs[arrayPosition - 72].GetComponent<Button>();
                        position = position - 80;
                        arrayPosition = arrayPosition - 72;
                    }
                    selectedObject.image.color = new Color(255, 255, 255, 255);

                }
            }//ifOPen

            if (Input.GetKeyDown("space"))
            {

                if (selectedObject.GetComponent<Menu>().changable)
                {
                    isOpen = true;
                    if (isOpen)
                    {
                        selectedObject.GetComponent<Menu>().go.transform.position = selectedObject.transform.position + new Vector3(0, 0, -10f);

                        selectedObject.GetComponent<Menu>().setOpen();
                        return;
                    }
                    else
                    {
                        selectedObject.GetComponent<Menu>().setClose();
                        return;
                    }
                }
            }//space
        }//isFreeze

        /************************/
        if (!isFreeze2)
        {
            if (!isOpen2)
            {
                if (Input.GetKeyDown(KeyCode.A))
                {
                    changeColor2();

                    if (position2 % 10 > 0)
                    {
                        selectedObject2 = numberInput2.inputs2[arrayPosition2 - 1].GetComponent<Button>();
                        arrayPosition2 = arrayPosition2 - 1;
                        position2 = position2 - 1;
                    }
                    else
                    {
                        selectedObject2 = numberInput2.inputs2[arrayPosition2 + 8].GetComponent<Button>();
                        position2 = position2 + 8;
                        arrayPosition2 = arrayPosition2 + 8;
                    }
                    selectedObject2.image.color = new Color(255, 255, 255, 255);

                }

                if (Input.GetKeyDown(KeyCode.D))
                {
                    changeColor2();
                    if (position2 % 10 < 8)
                    {
                        selectedObject2 = numberInput2.inputs2[arrayPosition2 + 1].GetComponent<Button>();
                        position2 = position2 + 1;
                        arrayPosition2 = arrayPosition2 + 1;
                    }
                    else
                    {
                        selectedObject2 = numberInput2.inputs2[arrayPosition2 - 8].GetComponent<Button>();
                        position2 = position2 - 8;
                        arrayPosition2 = arrayPosition2 - 8;
                    }

                    selectedObject2.image.color = new Color(255, 255, 255, 255); ;
                }

                if (Input.GetKeyDown(KeyCode.W))
                {
                    changeColor2();

                    if (position2 / 10 > 0)
                    {
                        selectedObject2 = numberInput2.inputs2[arrayPosition2 - 9].GetComponent<Button>();
                        position2 = position2 - 10;
                        arrayPosition2 = arrayPosition2 - 9;
                    }
                    else
                    {
                        selectedObject2 = numberInput2.inputs2[arrayPosition2 + 72].GetComponent<Button>();
                        position2 = position2 + 80;
                        arrayPosition2 = arrayPosition2 + 72;
                    }
                    selectedObject2.image.color = new Color(255, 255, 255, 255);
                }

                if (Input.GetKeyDown(KeyCode.S))
                {
                    changeColor2();

                    if (position2 / 10 < 8)
                    {
                        selectedObject2 = numberInput2.inputs2[arrayPosition2 + 9].GetComponent<Button>();
                        position2 = position2 + 10;
                        arrayPosition2 = arrayPosition2 + 9;
                    }
                    else
                    {
                        selectedObject2 = numberInput2.inputs2[arrayPosition2 - 72].GetComponent<Button>();
                        position2 = position2 - 80;
                        arrayPosition2 = arrayPosition2 - 72;
                    }
                    selectedObject2.image.color = new Color(255, 255, 255, 255);

                }
            }//ifOPen

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {

                if (selectedObject2.GetComponentInChildren<Menu>().changable)
                {
                    isOpen2 = true;
                    if (isOpen2)
                    {
                        selectedObject2.GetComponentInChildren<Menu>().go.transform.position = selectedObject2.transform.position + new Vector3(0, 0, -10f);
                        selectedObject2.GetComponentInChildren<Menu>().setOpen();
                        return;
                    }
                    else
                    {
                        selectedObject2.GetComponentInChildren<Menu>().setClose();
                        return;
                    }
                }
            }//space
        }//isFreeze2
    }//update

    void changeColor()
    {
        if (selectedObject.GetComponent<Menu>().changable)
            if (selectedObject.GetComponent<Menu>().isValid)
            {
                selectedObject.image.color = new Color(0, 1, 0, 0.5f);
            }
            else
            {
                selectedObject.image.color = new Color(255, 0, 37, 0.5f);
            }

        else
        {
            selectedObject.image.color = new Color(255, 255, 255, 0);
        }
    }
    void changeColor2()
    {
        if (selectedObject2.GetComponent<Menu>().changable)
            if (selectedObject2.GetComponent<Menu>().isValid)
            {
                selectedObject2.image.color = new Color(0, 1, 0, 0.5f);
            }
            else
            {
                selectedObject2.image.color = new Color(255, 0, 37, 0.5f);
            }
        else
        {
            selectedObject2.image.color = new Color(255, 255, 255, 0);
        }
    }
}
