/*
    Pause.cs controls pause functionality in Main game scene, hides ui when paused and displays pause menu ui when paused
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public Button resumeButton;
    public Button menuButton;
    public Image background;
    public Text pauseMenuText;
    public Text healthText;
    public Text healthNumText;
    public Text killText;
    public Text killNumText;
    private GameObject playerSphere;

    private bool Paused = false;

    // checks if game is paused or unpaused and calls respective functions
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(Paused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    // Pauses Main game scene, disables player's ability to shoot, hides ui and enables pause menu ui
    void PauseGame()
    {
        Time.timeScale = 0;
        
        Paused = true;
        GameObject playerSphere = GameObject.Find("Player");
        playerSphere.GetComponent<PlayerShooting>().enabled = false;
        healthText.gameObject.SetActive(false);
        healthNumText.gameObject.SetActive(false);
        killText.gameObject.SetActive(false);
        killNumText.gameObject.SetActive(false);
        background.gameObject.SetActive(true);
        pauseMenuText.gameObject.SetActive(true);
        resumeButton.gameObject.SetActive(true);
        menuButton.gameObject.SetActive(true);
    }

    // Resumes Main game scene, enables player's ability to shoot, hides pause menu ui and enables health/kill ui
    public void ResumeGame()
    {
        Time.timeScale = 1;
        
        Paused = false;
        GameObject playerSphere = GameObject.Find("Player");
        playerSphere.GetComponent<PlayerShooting>().enabled = true;
        healthText.gameObject.SetActive(true);
        healthNumText.gameObject.SetActive(true);
        killText.gameObject.SetActive(true);
        killNumText.gameObject.SetActive(true);
        background.gameObject.SetActive(false);
        pauseMenuText.gameObject.SetActive(false);
        resumeButton.gameObject.SetActive(false);
        menuButton.gameObject.SetActive(false);
    }
}
