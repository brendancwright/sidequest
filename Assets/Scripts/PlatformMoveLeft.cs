using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoveLeft : MonoBehaviour {

    public float MoveSpeed = 5;

    float StartPosX;

    bool PlayerPresent = false;

	// Use this for initialization
	void Start () {
        StartPosX = transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerPresent) {
            MoveLeft();
        } else if (!PlayerPresent && transform.position.x > StartPosX) {
            MoveRight();
        }
	}

    void MoveLeft() {
        transform.position += Vector3.left / MoveSpeed * 2;
    }

    void MoveRight() {
        transform.position -= Vector3.left / MoveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            PlayerPresent = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "Player") {
            PlayerPresent = false;
        }
    }
}
