/*
    DataManager.cs controls the health ui number, kill ui number, and win condition
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class DataManager : MonoBehaviour
{

    public Text HealthNumber;
    public Text KillNumber;

    // at start of scene set kill count to 0
    void Start()
    {
        Enemy.enemyDeath = 0;
    }

    // updates health and kill ui to current health and kill numbers
    // if 10 enemies are killed transition to credits
    void FixedUpdate(){
        HealthNumber.text = Player.playerHealth.ToString();
        KillNumber.text = Enemy.enemyDeath.ToString();
        if (Enemy.enemyDeath >= 10){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
