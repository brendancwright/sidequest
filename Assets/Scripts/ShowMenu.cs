using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMenu : MonoBehaviour {

    bool MenuActive;

    public GameObject ThisMenu;

	// Use this for initialization
	void Start () {
        MenuActive = false;
        ThisMenu.SetActive(false);
        Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Show() {
        MenuActive = !MenuActive;

        if (MenuActive) {
            ThisMenu.SetActive(true);
            Time.timeScale = 0;
        } else {
            ThisMenu.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
