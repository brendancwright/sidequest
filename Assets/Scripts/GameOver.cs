using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

    public UnityEngine.GameObject Player;
    public Canvas GameOverMenu;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Player == null) {
            GameOverMenu.gameObject.SetActive(true);
        }
	}
}
