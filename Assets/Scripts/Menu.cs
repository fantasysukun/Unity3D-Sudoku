using UnityEngine;
using System.Collections;
using System;

public class Menu : MonoBehaviour {

    public GameObject numberMenu;
    public bool isOpen;
    public int Location;
    public GameObject go;

	// Use this for initialization
	void Start () {
        go = (GameObject)Instantiate(numberMenu);
        go.transform.SetParent(transform);
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
