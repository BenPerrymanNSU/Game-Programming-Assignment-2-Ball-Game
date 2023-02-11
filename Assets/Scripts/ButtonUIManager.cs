using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class ButtonUIManager : MonoBehaviour
{
    public void SceneForward(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SceneReturn(){
        SceneManager.LoadScene(0);
    }
}
