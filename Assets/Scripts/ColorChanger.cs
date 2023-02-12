/*
    ColorChanger.cs controls the color of the player ball material
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public GameObject playerSphere;

    // calls function below at start
    void Start(){
        Invoke("changeColorSphere", 0);
    }

    // based on color dropdown choice, select case based on value, finds new player after death
    public void changeColorSphere(){
        switch(UIManager.color){
            case 3:
                playerSphere = GameObject.Find("Player");
                playerSphere.GetComponent<Renderer>().material.color = Color.green;
                break;

            case 2:
                playerSphere = GameObject.Find("Player");
                playerSphere.GetComponent<Renderer>().material.color = Color.black;
                break;

            case 1:
                playerSphere = GameObject.Find("Player");
                playerSphere.GetComponent<Renderer>().material.color = Color.blue;
                break;

            default:
                playerSphere = GameObject.Find("Player");
                playerSphere.GetComponent<Renderer>().material.color = Color.white;
                break;
      }
    }
}
