using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class numbercontroller : MonoBehaviour {

    public static Button selectedObject;
    public Button firstObject;
    public int position;
    public int arrayPosition = 0;
    public static bool isOpen = false;

    // Use this for initialization
    void Start () {
        selectedObject = firstObject;
        position = selectedObject.GetComponent<Menu>().Location;

        selectedObject.image.color = new Color(255,255,255,255);
    }

    // Update is called once per frame
    void Update() {
          if (!isOpen) { 
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
           
            

            if (selectedObject.GetComponentInChildren<Menu>().changable)
            {
                isOpen = true;
                if (isOpen)
                {
                    selectedObject.GetComponentInChildren<Menu>().go.transform.position = selectedObject.transform.position + new Vector3(0, 0, -10f);
                    selectedObject.GetComponentInChildren<Menu>().setOpen();
                    return;
                }
                else
                {
                    selectedObject.GetComponentInChildren<Menu>().setClose();
                    return;
                }
            }
            
            
        }

    }//update

    void changeColor()
    {
        if (selectedObject.GetComponent<Menu>().changable)
            selectedObject.image.color = new Color(0, 1, 0, 0.5f);
        else {
            selectedObject.image.color = new Color(255, 255, 255, 0);
        }
    }
}
