/*
    Player.cs is a script from the Kodeco tutorial, it controls the player health and collision
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour {

    public int health;
    public static int playerHealth;
    public event Action<Player> onPlayerDeath;

    // keeps player health number up to date
    void Update(){
        playerHealth = health;
    }

    // if an enemy collides with player subtract health, if health is empty call player death event
    void collidedWithEnemy(Enemy enemy) {
        enemy.Attack(this);
        if(health <= 0) {
            playerHealth = 0;
            if(onPlayerDeath != null) {
                onPlayerDeath(this);
            }
        }
    }

    // if player collides with enemy, call above function
    void OnCollisionEnter (Collision col) {
        Enemy enemy = col.collider.gameObject.GetComponent<Enemy>();
        if(enemy) {
            collidedWithEnemy(enemy);
        }
    }
}
