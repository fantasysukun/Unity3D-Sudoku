using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class numbercontroller : MonoBehaviour {

    public Button selectedObject;
    public int position;
    public int arrayPosition = 0;
    public bool isOpen = false;

    // Use this for initialization
    void Start () {

        position = selectedObject.GetComponent<Menu>().Location;

        selectedObject.image.color = new Color(255,255,255,255);
    }

    // Update is called once per frame
    void Update() {
          if (!isOpen) { 
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    selectedObject.image.color = new Color(255, 255, 255, 0);
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
                    selectedObject.image.color = new Color(255, 255, 255, 0);
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
                    selectedObject.image.color = new Color(255, 255, 255, 0);
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
                    selectedObject.image.color = new Color(255, 255, 255, 0);
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
           
            isOpen = !isOpen;
            if (isOpen)
            {
                selectedObject.GetComponentInChildren<Menu>().go.transform.position = selectedObject.transform.position + new Vector3(0, 0, -10f);
                selectedObject.GetComponentInChildren<Menu>().setOpen();
            }
            else
            {
                selectedObject.GetComponentInChildren<Menu>().setClose();
            }
        }

    }
}
