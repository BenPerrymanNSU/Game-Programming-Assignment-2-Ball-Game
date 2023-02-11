using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public GameObject playerSphere;

    void Start(){
        Invoke("changeColorSphere", 0);
    }

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
