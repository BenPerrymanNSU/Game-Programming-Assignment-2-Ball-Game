/*
    GameController.cs is a script from the Kodeco tutorial, it controls the player death and restarting the scene on death
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameController : MonoBehaviour {

    public EnemyProducer enemyProducer;
    public GameObject playerPrefab;
    private GameObject dataManager;

    ColorChanger ColorChangerScript;
    SizeChanger SizeChangerScript;

    // at start of scene find player object and set player death, ensures game is not paused at start
    void Start () {
        var player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player.onPlayerDeath += onPlayerDeath;
        Time.timeScale = 1;
    }
	
    // removes player object, stops enemy spawns, disables pausing during respawn, calls function below
    void onPlayerDeath(Player player) {
        enemyProducer.SpawnEnemies(false);
        Destroy(player.gameObject);

        GameObject dataManager = GameObject.Find("Data Manager");
        dataManager.GetComponent<Pause>().enabled = false;

        Invoke("restartGame", 3);
    }

    // destroys remaining enemy objects, creates a new player clone, renames clone to player, resets camera, starts enemy spawning,
    // reactivates pause functionality, sets kill count to 0, calls color change script, calls size change script
    void restartGame() {
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var enemy in enemies)
        {
        Destroy(enemy);
        }

        var playerObject = Instantiate(playerPrefab, new Vector3(0, 0.5f, 0), Quaternion.identity) as GameObject;
        playerObject.name = "Player";
        var cameraRig = Camera.main.GetComponent<CameraRig>();
        cameraRig.target = playerObject;
        enemyProducer.SpawnEnemies(true);
        playerObject.GetComponent<Player>().onPlayerDeath += onPlayerDeath;
        GameObject dataManager = GameObject.Find("Data Manager");
        dataManager.GetComponent<Pause>().enabled = true;
        Enemy.enemyDeath = 0;
        ColorChangerScript = FindObjectOfType<ColorChanger>();
        ColorChangerScript.changeColorSphere();
        SizeChangerScript = FindObjectOfType<SizeChanger>();
        SizeChangerScript.changeSizeSphere();
    }
}
