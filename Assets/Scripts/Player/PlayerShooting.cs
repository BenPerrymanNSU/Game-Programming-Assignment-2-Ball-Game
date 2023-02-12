/*
    PlayerShooting.cs is a script from the Kodeco tutorial, it controls the player's ability to shoot
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

    public Projectile projectilePrefab;
    public LayerMask mask;

    // checks for mouse clicks
    void Update () {
        bool mouseButtonDown = Input.GetMouseButtonDown(0);
        if(mouseButtonDown) {
            raycastOnMouseClick();  
        }
    }

    // potentially keeps the projectil from falling
    void raycastOnMouseClick () {
        RaycastHit hit;
        Ray rayToFloor = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(rayToFloor, out hit, 100.0f, mask, QueryTriggerInteraction.Collide)) {
            shoot(hit);
        }
    }

    // creates projectiles
    void shoot(RaycastHit hit){
        var projectile = Instantiate(projectilePrefab).GetComponent<Projectile>();
        var pointAboveFloor = hit.point + new Vector3(0, this.transform.position.y, 0);

        var direction = pointAboveFloor - transform.position;

        var shootRay = new Ray(this.transform.position, direction);

        Physics.IgnoreCollision(GetComponent<Collider>(), projectile.GetComponent<Collider>());
        projectile.FireProjectile(shootRay);
    }
}
