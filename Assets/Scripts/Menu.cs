using UnityEngine;
using System.Collections;
using System;

public class Menu : MonoBehaviour {

    public GameObject numberMenu;
    public GameObject numberMenu2;
    public int Location;
    public int value;
    public bool isValid = true;
    public bool changable;
    public GameObject go;

	// Use this for initialization
	void Start () {
        if (transform.parent.tag == "player1")
        {
            go = (GameObject)Instantiate(numberMenu);
            go.transform.SetParent(transform);
        }
        else
        {
            go = (GameObject)Instantiate(numberMenu2);
            go.transform.SetParent(transform);
        }
    }
	
    public void setOpen() {
        go.SetActive(true);
        return;
    }
    public void setClose()
    {
        go.SetActive(false);
        return;
    }

}
