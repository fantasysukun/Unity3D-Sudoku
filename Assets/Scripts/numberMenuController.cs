using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class numberMenuController : MonoBehaviour
{

    public static GameObject[] inputs;
    public GameObject selectedObject;
    public int position;
    public int selectedValue;


    // Use this for initialization
    void Awake()
    {
        

    }

    void Start()
    {
        int size = this.transform.childCount;
        inputs = new GameObject[size];
        for (int i = 0; i < inputs.Length; i++)
        {
            inputs[i] = this.transform.GetChild(i).gameObject;
        }
        selectedObject = inputs[0];
        position = 0;
        selectedObject.GetComponent<Image>().color = new Color(255, 0, 0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            selectedObject.GetComponent<Image>().color = new Color(255, 255, 255);
            if (position == 9)
            {
                //do nothing
            }
            else if (position % 3 > 0)
            {
                selectedObject = inputs[position - 1];
                position = position - 1;
            }
            else
            {
                selectedObject = inputs[position + 2];
                position = position + 2;

            }
            selectedObject.GetComponent<Image>().color = new Color(255, 0, 0);

        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            selectedObject.GetComponent<Image>().color = new Color(255, 255, 255);
            if (position == 9)
            {
                //do nothing
            }
            else if (position % 3 < 2)
            {
                selectedObject = inputs[position + 1];
                position = position + 1;

            }
            else
            {
                selectedObject = inputs[position - 2];
                position = position - 2;
            }

            selectedObject.GetComponent<Image>().color = new Color(255, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            selectedObject.GetComponent<Image>().color = new Color(255, 255, 255);
            if (position == 9)
            {
                selectedObject = inputs[8];
                position = position - 1;
            }
            else if (position / 3 > 0)
            {
                selectedObject = inputs[position - 3];
                position = position - 3;
            }
            else
            {
                //do nothing on firstline
            }
            selectedObject.GetComponent<Image>().color = new Color(255, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            selectedObject.GetComponent<Image>().color = new Color(255, 255, 255);
            if (position / 3 < 2)
            {
                selectedObject = inputs[position + 3];
                position = position + 3;
            }
            else
            {
                selectedObject = inputs[9];
                position = 9;

            }
            selectedObject.GetComponent<Image>().color = new Color(255, 0, 0);
        }

        if (Input.GetKeyDown("space"))
        {
            print(1);
            if(selectedObject.GetComponentInChildren<Text>().text == "x")
            {
                print(3);
                this.GetComponentInParent<Menu>().isOpen = false;
                numbercontroller.isOpen = false;
                this.GetComponentInParent<Menu>().setClose();
                return;
            }
            else
            {
                print(4);
                selectedValue = Int32.Parse(selectedObject.GetComponentInChildren<Text>().text);
                this.GetComponentInParent<Menu>().value = selectedValue;
                numbercontroller.selectedObject.GetComponentInChildren<Text>().text = selectedValue.ToString();
            }
            print(2);



            /*
            if (isOpen)
            {
                selectedObject.GetComponentInChildren<Menu>().go.transform.position = selectedObject.transform.position + new Vector3(0, 0, -10f);
                selectedObject.GetComponentInChildren<Menu>().setOpen();
            }
            else
            {
                selectedObject.GetComponentInChildren<Menu>().setClose();
            }*/
        }
    }
}