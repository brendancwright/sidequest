using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeShaftTrap : MonoBehaviour {

    float StartPosY;

    public Transform PlayerTransform;

    public int AggroRange;

    float DistanceFromPlayer;

    private bool CanMove = true;

    private bool ShouldReturnToStartPos;

    private bool IsPlayerPresent;

	// Use this for initialization
	void Start () {
        StartPosY = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(IsPlayerPresent);

        IsPlayerPresent = CheckForPlayer();

        if ((CanMove == false) && (transform.position.y == StartPosY)) {
            CanMove = true;

        }

		if ((IsPlayerPresent) && (CanMove)) {
            
            MoveUp();

            if (ShouldReturnToStartPos) {
                CanMove = false;
            }
        }
	}

    private bool CheckForPlayer() {
        if (PlayerTransform != null) {
            DistanceFromPlayer = Vector3.Distance(PlayerTransform.position, transform.position);
        }

        if (DistanceFromPlayer < AggroRange) {
            return true;
        }
        else {
            return false;
        }
    }

    private void MoveUp() {
        transform.position += Vector3.up / 20;
    }

    private void ReturnToStartPos() {
        transform.position += Vector3.down / 40;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("WTF");
        if (collision.tag == "Stop") {
            ShouldReturnToStartPos = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "Stop") {
            ShouldReturnToStartPos = false;
        }
    }
}
