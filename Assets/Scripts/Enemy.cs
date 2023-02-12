/*
    Enemy.cs is a script from the Kodeco tutorial, it controls enemy game objects
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float moveSpeed;
    public int health;
    public static int enemyDeath;
    public int damage;
    public Transform targetTransform;

    // sets target, speed, and health on spawn
    public void Initialize(Transform target, float moveSpeed, int health) {
        this.targetTransform = target;
        this.moveSpeed = moveSpeed;
        this.health = health;
    }

    // keeps the enemies tracking towards the player
    void FixedUpdate () {
        if(targetTransform != null) {
            this.transform.position = Vector3.MoveTowards(this.transform.position, targetTransform.transform.position, Time.deltaTime * moveSpeed);
        }
    }

    // deducts enemy health if player projectile collides, adds to kill count for win condition, and destroys the enemy object
    public void TakeDamage(int damage) {
        health -= damage;
        if(health <= 0) {
            ++enemyDeath;
            Destroy(this.gameObject);
        }
    }

    // deducts from player health and destroys the enemy
    public void Attack(Player player) {
        player.health -= this.damage;
        Destroy(this.gameObject);
    }
}
