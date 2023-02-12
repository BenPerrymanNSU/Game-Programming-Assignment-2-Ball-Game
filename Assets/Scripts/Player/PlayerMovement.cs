/*
    PlayerMovement.cs is a script from the Kodeco tutorial, it controls user input interactions for ball movement
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float acceleration;
    public float maxSpeed;

    private Rigidbody rigidBody;
    private KeyCode[] inputKeys;
    private Vector3[] directionsForKeys;

    // gets keyboard keys and assigns them to vector directions
    void Start () {
        inputKeys = new KeyCode[] { KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D };
        directionsForKeys = new Vector3[] { Vector3.forward, Vector3.left, Vector3.back, Vector3.right };
        rigidBody = GetComponent<Rigidbody>();
    }
	
    // calculates key pressed and sets acceleration
    void FixedUpdate () {
        for (int i = 0; i < inputKeys.Length; i++){
            var key = inputKeys[i];
            acceleration = UIManager.speed;

            if(Input.GetKey(key)) {
                Vector3 movement = directionsForKeys[i] * acceleration * Time.deltaTime;
                movePlayer(movement);
            }
        }
    }

    // keeps the player from moving too fast and moves the player
    void movePlayer(Vector3 movement) {
        if(rigidBody.velocity.magnitude * acceleration == maxSpeed) {
            rigidBody.AddForce(movement * -1);
        }
        else {
            rigidBody.AddForce(movement);
        }
    }

}
