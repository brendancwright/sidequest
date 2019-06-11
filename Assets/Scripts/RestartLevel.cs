using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartLevel : MonoBehaviour {
	//This is for death or falling off the map
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col){
		//Only players can make this happen
		if (col.tag == "Player") {
            //reload same level
            Restart();
		}
	}

    public void Restart() {
        Application.LoadLevel(Application.loadedLevel);
    }
}
