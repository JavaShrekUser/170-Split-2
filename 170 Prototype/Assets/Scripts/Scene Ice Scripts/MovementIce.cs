using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MovementIce : MonoBehaviour
{
    public Rigidbody2D rb;      // Rigidbody variable
    public float speed;         // player movement speed 

    void Update()
    {
        //Movement();
    }

    void Movement(){
        // Get One Direction^^
        float horizontalmove;
        horizontalmove = Input.GetAxis("Horizontal");
        Debug.Log("horizontalmove = " + horizontalmove);

        // PlayerMovement method
        if(horizontalmove != 0){
            Debug.Log("Not on ice");
            rb.velocity = new Vector2(horizontalmove * speed, rb.velocity.y);
        }
    }

    void MovementAfterIceR(){
        float horizontalmove;
        horizontalmove = Input.GetAxisRaw("Horizontal");
        Debug.Log("horizontalmove right ice = " + horizontalmove);
        // PlayerMovement Method
        if(horizontalmove == -1){
            speed *= -1;
        }
    }

    void MovementAfterIceL(){
        float horizontalmove;
        horizontalmove = Input.GetAxisRaw("Horizontal");
        Debug.Log("horizontalmove left ice = " + horizontalmove);
        // PlayerMovement Method
        if(horizontalmove == 1){
            speed *= -1;
        }
    }

    // Collision detector, returns true while player keep coliding the ice
    private void OnCollisionStay2D(Collision2D col){
        // if collide with ice do sliding
        if(col.gameObject.tag == "Ice"){
            rb.velocity = new Vector2(speed, -10);
        // if not collide do normal movement
        }else if(col.gameObject.tag == "WallR"){
            MovementAfterIceR();
        }else if(col.gameObject.tag == "WallL"){
            MovementAfterIceL();
        }else{
            Movement();
        }
  }

    /*private void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "WallR"){
            Debug.Log("Touching right wall");
            MovementAfterIce();
        }
        if(col.gameObject.tag == "WallL"){
            Debug.Log("Touching left wall");
        }
    }*/
}

