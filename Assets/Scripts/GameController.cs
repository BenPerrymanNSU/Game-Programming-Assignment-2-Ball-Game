﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameController : MonoBehaviour {

  public EnemyProducer enemyProducer;
  public GameObject playerPrefab;

  ColorChanger ColorChangerScript;

	void Start () {
    var player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    player.onPlayerDeath += onPlayerDeath;
	}
	
  void onPlayerDeath(Player player) {
    enemyProducer.SpawnEnemies(false);
    Destroy(player.gameObject);

    Invoke("restartGame", 3);
  }

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
    Enemy.enemyDeath = 0;
    ColorChangerScript = FindObjectOfType<ColorChanger>();
    ColorChangerScript.changeColorSphere();
  }
}
