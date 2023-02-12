/*
    SizeChanger.cs controls the size of the ball, changes its position to not clip into the ground
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeChanger : MonoBehaviour
{
    public GameObject playerSphere;
    private float playerSize = 1.0f;

    // on start of scene calls function below
    void Start(){
        Invoke("changeSizeSphere", 0);
    }

    // finds the new player after death and sets size according to dropdown menu value selected
    public void changeSizeSphere(){
        switch(UIManager.size){
            case 2:
                playerSphere = GameObject.Find("Player");
                playerSize = 3.0f;
                break;

            case 1:
                playerSphere = GameObject.Find("Player");
                playerSize = 2.0f;
                break;

            default:
                playerSphere = GameObject.Find("Player");
                playerSize = 1.0f;
                break;
      }

        playerSphere.transform.localScale = new Vector3(playerSize,playerSize,playerSize);
        playerSphere.transform.localPosition = new Vector3(playerSphere.transform.localPosition.x, 0.5f * playerSize, playerSphere.transform.localPosition.z);

    }
}
