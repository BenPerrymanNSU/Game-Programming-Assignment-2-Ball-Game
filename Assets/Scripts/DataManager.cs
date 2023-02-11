using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class DataManager : MonoBehaviour
{

    public Text HealthNumber;
    public Text KillNumber;

    // Start is called before the first frame update
    void Start()
    {

    }

    void FixedUpdate(){
        HealthNumber.text = Player.playerHealth.ToString();
        KillNumber.text = Enemy.enemyDeath.ToString();
        if (Enemy.enemyDeath >= 10){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
