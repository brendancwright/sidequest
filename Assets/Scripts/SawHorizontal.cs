using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawHorizontal : MonoBehaviour {

    // How fast to move along y axis
    public int MoveSpeed = 15;

    // How far to move along y axis
    public float MoveDistance = 2;

    // Where object starts on y axis
    public float StartPos;

    // Highest point on y axis object should travel
    public float RightLimit;

    // Lowest point on y axis object should travel
    public float LeftLimit;

    // Which direction is object moving?
    private bool IsMoveRight = true;

    // Make object rotate faster or slower
    public float RotationMultiplier = 350;

	// Use this for initialization
	void Start () {
        StartPos = transform.position.x;
        RightLimit = StartPos + MoveDistance;
        LeftLimit = StartPos - MoveDistance;
	}
	
	// Update is called once per frame
	void Update () {

        // Patrol logic
        if (IsMoveRight) {
            RotateCW();
            MoveRight();
        } else {
            RotateCCW();
            MoveLeft();
        }
	}

    // Moves object along the y axis in a positive direction
    void MoveRight() {
        transform.position += (Vector3.right / MoveSpeed);

        // Has exceeded limit? Flip direction
        if (transform.position.x > RightLimit) {
            IsMoveRight = false;
        }
    }

    // Moves object along the y axis in a negative direction
    void MoveLeft() {
        transform.position -= (Vector3.right / MoveSpeed);

        // Has exceeded limit? Flip direction
        if (transform.position.x < LeftLimit) {
            IsMoveRight = true;
        }
    }

    // Rotates object counter clockwise
    void RotateCCW() {
        transform.Rotate(0, 0, (Time.deltaTime * RotationMultiplier));
    }

    // Rotates object clockwise
    void RotateCW() {
        transform.Rotate(0, 0, (-Time.deltaTime * RotationMultiplier));
    }
}
