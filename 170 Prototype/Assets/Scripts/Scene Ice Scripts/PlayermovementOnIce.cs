using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayermovementOnIce : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;         // player movement speed 
    public bool touchIce;       // Helps to determine in playermovement

    void Update()
    {
        Debug.Log("touchIce status1 = "+touchIce);
        //Movement();
    }

    void Movement(){
        // Get One Direction^^
        float horizontalmove;
        horizontalmove = Input.GetAxis("Horizontal");
        touchIce = false;

        // PlayerMovement by if the player is touchin the ice (still working, not fully functional)
        if(horizontalmove != 0&&!touchIce){
            Debug.Log("Not on ice");
            rb.velocity = new Vector2(horizontalmove * speed, rb.velocity.y);
        }else if(touchIce){
            rb.velocity = new Vector2(speed, -10);
        }
    }

    // Collision detector, returns true while player touching ice
    private void OnCollisionEnter2D(Collision2D col){
        // if collide with ice
        if(col.gameObject.tag == "Ice"){
            Debug.Log("Collision detected = "+touchIce);
            rb.velocity = new Vector2(speed, -10);
            touchIce = true;
            Debug.Log("touchIce status2 = "+touchIce);
        }else{
            Movement();
        }
  }
}
