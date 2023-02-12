/*
    Projectile.cs is a script from the Kodeco tutorial, controls player projectile's firing, direction, and collision
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed;
    public int damage;

    Vector3 shootDirection;
	
    // Keeps the projectile firing from the players current direction
    void FixedUpdate () {
        this.transform.Translate(shootDirection * speed, Space.World);
    }

    // controls the spawning of projectiles
    public void FireProjectile(Ray shootRay) {
        this.shootDirection = shootRay.direction;
        this.transform.position = shootRay.origin;
        rotateInShootDirection();
    }

    // Rotates projectile to where the player is looking
    void rotateInShootDirection() {
        Vector3 newRotation = Vector3.RotateTowards(transform.forward, shootDirection, 0.01f, 0.0f);
        transform.rotation = Quaternion.LookRotation(newRotation);
    }

    // controls collision wiht enemys, damages enemy and deletes the projectile
    void OnCollisionEnter (Collision col) {
        Enemy enemy = col.collider.gameObject.GetComponent<Enemy>();
        if(enemy) {
          enemy.TakeDamage(damage);
        }
        Destroy(this.gameObject);
    }    
}
