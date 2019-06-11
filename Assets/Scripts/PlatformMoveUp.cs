using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoveUp : MonoBehaviour {

    public float MoveSpeed = 5;

    float StartPosY;

    bool PlayerPresent = false;

	// Use this for initialization
	void Start () {
        StartPosY = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerPresent) {
            MoveUp();
        } else if (!PlayerPresent && transform.position.y > StartPosY) {
            MoveDown();
        }
	}

    void MoveUp() {
        transform.position += Vector3.up / MoveSpeed * 2;
    }

    void MoveDown() {
        transform.position -= Vector3.up / MoveSpeed;
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
