/*
    CaneraRig.cs is a script from the Kodeco tutorial, it controls the camera tracking the player in the Main game scene
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRig : MonoBehaviour {

    public float moveSpeed;
    public GameObject target;

    private Transform rigTransform;

    // I'm not sure how this line specifically works, but it seem to prime the camera for transforming
    void Start () {
        rigTransform = this.transform.parent;
    }

    // targets player location and moves it
    void FixedUpdate () {
        if(target == null){
            return;
        }

        rigTransform.position = Vector3.Lerp(rigTransform.position, target.transform.position, Time.deltaTime * moveSpeed);
    }
}
