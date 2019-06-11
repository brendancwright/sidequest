using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawVertical : MonoBehaviour {

    // How fast to move along y axis
    public int MoveSpeed = 15;

    // How far to move along y axis
    public float MoveDistance = 2;

    // Where object starts on y axis
    public float StartPos;

    // Highest point on y axis object should travel
    public float TopLimit;

    // Lowest point on y axis object should travel
    public float BottomLimit;

    // Which direction is object moving?
    private bool IsMoveUp = true;

    // Make object rotate faster or slower
    public float RotationMultiplier = 350;

	// Use this for initialization
	void Start () {
        StartPos = transform.position.y;
        TopLimit = StartPos + MoveDistance;
        BottomLimit = StartPos - MoveDistance;
	}
	
	// Update is called once per frame
	void Update () {
        Rotate();

        // Patrol logic
        if (IsMoveUp) {
            MoveUp();
        } else {
            MoveDown();
        }
	}

    // Moves object along the y axis in a positive direction
    void MoveUp() {
        transform.position += (Vector3.up / MoveSpeed);

        // Has exceeded limit? Flip direction
        if (transform.position.y > TopLimit) {
            IsMoveUp = false;
        }
    }

    // Moves object along the y axis in a negative direction
    void MoveDown() {
        transform.position -= (Vector3.up / MoveSpeed);

        // Has exceeded limit? Flip direction
        if (transform.position.y < BottomLimit) {
            IsMoveUp = true;
        }
    }

    // Rotates object
    void Rotate() {
        transform.Rotate(0, 0, (Time.deltaTime * RotationMultiplier));
    }
}
