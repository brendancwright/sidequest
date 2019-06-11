using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaceFace : MonoBehaviour {

    // How many times to shake
    public int MoveCounter;

    // How many times he shakes before falling
    public int MoveLimit;

    // How fast to move along x axis
    public int XMoveSpeed = 30;

    // How fast to move along y axis
    public int YMoveSpeed = 2;

    // How far to move along x axis
    public float MoveDistance = .2f;

    // Where object starts on x axis
    public float StartPosX;

    // Where object starts on y axis
    public float StartPosY;

    // Highest point on x axis object should travel
    public float LeftLimit;

    // Lowest point on x axis object should travel
    public float RightLimit;

    // Which direction is object moving?
    private bool IsMoveRight = true;

    // Is object on ground?
    public bool IsGrounded = false;

    private Rigidbody2D ThisRigidBody;

    public bool CanSlam = true;

    public bool PlayerPresent = false;

    public Transform PlayerTransform;

    public int AggroRange = 1;

    float DistanceFromPlayer;

    AudioSource ThisAudio;

    // Use this for initialization
    private void Start() {
        ThisAudio = gameObject.GetComponent<AudioSource>();
        ThisRigidBody = gameObject.GetComponent<Rigidbody2D>();

        MoveCounter = 0;
        StartPosX = transform.position.x;
        StartPosY = transform.position.y;
        LeftLimit = StartPosX + MoveDistance;
        RightLimit = StartPosX - MoveDistance;
    }

    // Update is called once per frame
    private void Update() {
        PlayerPresent = CheckForPlayer();

        // Patrol logic
        if (CanSlam && PlayerPresent) {
            if (MoveCounter < MoveLimit) {
                if (IsMoveRight) {
                    MoveRight();
                }
                else {
                    MoveLeft();
                    MoveCounter++;
                }
            }
            else if (MoveCounter == MoveLimit) {
                ThisRigidBody.constraints = RigidbodyConstraints2D.FreezePositionX;
                ThisRigidBody.freezeRotation = true;
                Slam();

                if (IsGrounded) {
                    CanSlam = false;
                    MoveCounter = 0;
                }
            }
        } else if (!CanSlam) {
            if (transform.position.y < StartPosY) {
                MoveUp();
            } else {
                CanSlam = true;
            }
        }
    }

    // Moves object along the x axis in a positive direction
    private void MoveRight() {
        transform.position += (Vector3.right / XMoveSpeed);

        // Has exceeded limit? Flip direction
        if (transform.position.x > RightLimit) {
            IsMoveRight = false;
        }
    }

    // Moves object along the x axis in a negative direction
    private void MoveLeft() {
        transform.position -= (Vector3.right / XMoveSpeed);

        // Has exceeded limit? Flip direction
        if (transform.position.x < LeftLimit) {
            IsMoveRight = true;
        }
    }

    // Moves object along the y axis in a positive direction
    private void MoveUp() {
        transform.position += Vector3.up / 40;
    }

    // SLAM!
    private void Slam() {
        transform.position += (Vector3.down / YMoveSpeed);
    }

    private bool CheckForPlayer() {
        if (PlayerTransform != null) {
            DistanceFromPlayer = Vector3.Distance(PlayerTransform.position, transform.position);
        }

        if (DistanceFromPlayer < AggroRange) {
            return true;
        } else {
            return false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Ground") {
            IsGrounded = true;
            ThisAudio.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "Ground") {
            IsGrounded = false;
        }
    }
}
