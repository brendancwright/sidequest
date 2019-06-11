using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour {

    public Canvas MenuCanvas;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void ShowMenu() {
        MenuCanvas.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
