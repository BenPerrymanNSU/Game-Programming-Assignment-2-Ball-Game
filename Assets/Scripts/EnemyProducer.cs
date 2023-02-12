/*
    EnemyProducer.cs is a script from the Kodeco tutorial, it controls the spawning of enemy objects, setting position, health, and speed
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProducer : MonoBehaviour {

    public bool shouldSpawn;
    public Enemy[] enemyPrefabs;
    public float[] moveSpeedRange;
    public int[] healthRange;

    Bounds spawnArea;
    GameObject player;

    // keeps enemy game object spawning in the player area
    void Start () {
        spawnArea = this.GetComponent<BoxCollider>().bounds;
        SpawnEnemies(shouldSpawn);
        InvokeRepeating("spawnEnemy", 0.5f, 1.0f);
    }

    // keeps enemies spawning if player is still alive
    public void SpawnEnemies(bool shouldSpawn) {
        if(shouldSpawn) {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        this.shouldSpawn = shouldSpawn;
    }

    // spawns enemy with random health, speed, and position
    void spawnEnemy() {
        if(shouldSpawn == false || player == null) {
            return;
        }
        int index = Random.Range(0, enemyPrefabs.Length);
        var newEnemy = Instantiate(enemyPrefabs[index], randomSpawnPosition(), Quaternion.identity) as Enemy;
        newEnemy.Initialize(player.transform, 
        Random.Range(moveSpeedRange[0], moveSpeedRange[1]), 
        Random.Range(healthRange[0], healthRange[1]));
    }
    
    // controls the random spawn position
    Vector3 randomSpawnPosition() {
        float x = Random.Range(spawnArea.min.x, spawnArea.max.x);
        float z = Random.Range(spawnArea.min.z, spawnArea.max.z);
        float y = 0.5f;

        return new Vector3(x, y, z);
    }


}
