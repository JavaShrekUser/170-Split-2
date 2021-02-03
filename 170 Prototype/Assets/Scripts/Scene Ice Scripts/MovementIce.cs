using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MovementIce : MonoBehaviour
{
    // Horizontal Movement Variables
    public Rigidbody2D rb;              // Rigidbody variable
    [Range(0, 5)]
    public float movementSpeed;         // Player movement movementSpeed 
    [Range(0, 5)]
    public float speedOnIce;            // Movement speed on ice
    public float Direction;             // Player's direction choice after collide with somthin on ice
    public bool onIce;                  // If player is on ice
    public bool onLeft;                 // If player touch left boundary
    public bool onRight;                // If player touch right boundary

    // Vertical Movement Variables
    public float jumpForce = 20f;
    [Range(0,1)]
    public float jumpHeightReduce = 0.5f;
    private bool groundCheck2 = true;

    //Platform Collision Variables
    public Transform feet;
    public LayerMask groundLayers;
    public Collider2D player;
    public GameObject dialogueBox;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Check if Space is pressed down and touching the ground at the same time
        if(Input.GetButtonDown("Jump") && IsGrounded()){
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            groundCheck2 = true;
            
            //comment out for future need --- Access from playerMovement code to enemyMovement variable
            //monsterCanMove.canMove = !(monsterCanMove.canMove);
        }
        else if(groundCheck2 == false){
            groundCheck2 = (Physics2D.OverlapBox(feet.position, new Vector2(0.25f, .5f), 0f, groundLayers) != null);
        }
        //Check if Space is released up before it reached the maximum jump height
        if(Input.GetButtonUp("Jump") && rb.velocity.y > 0){
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * jumpHeightReduce);
        }
    }

    void FixedUpdate(){
        // Get horizontal velocity
        float horizontalmove = rb.velocity.x*movementSpeed;
        horizontalmove += Input.GetAxisRaw("Horizontal");
        // Direction play choose after collide something on ice
        Direction = Input.GetAxisRaw("Horizontal");
        Debug.Log("Direction = " + Direction);

        // PlayerMovement method (Based on if player stand on the ice)
        if(horizontalmove != 0 && !onIce){                                          // If not on ice, do normal movement
            Debug.Log("Not on ice");
            rb.velocity = new Vector2(horizontalmove, rb.velocity.y);
        }else if(onIce){                                                            // if on ice, do sliding movement
            Debug.Log("On Ice");
            
            // Player movement direction on ice after jumping from a ground platform
            if(horizontalmove > 0){                                                 // If jumping from ground to ice towards right, keep sliding to the right
                while(speedOnIce < 0){
                    speedOnIce *= -1;
                }
                rb.velocity = new Vector2(speedOnIce, rb.velocity.y);
            }else if(horizontalmove > 0){                                           // If jumping from ground to ice towards left, keep sliding to the left
                while(speedOnIce < 0){
                    speedOnIce *= -1;
                }
                rb.velocity = new Vector2(speedOnIce, rb.velocity.y);
            }
            // ---------------------------------------------------------------------

            // Test if player touch an obstacle while on ice
            if(onRight&&Direction == -1){                                           
                speedOnIce *= -1;
                onRight = false;
            }
            if(onLeft&&Direction == 1){
                speedOnIce *= -1;
                onLeft = false;
            }
            // ---------------------------------------------------------------------

            //Check if Space is pressed down and touching the ground at the same time
            if(Input.GetButtonDown("Jump") && IsGrounded()){
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                groundCheck2 = true;
            }else if(groundCheck2 == false){
                groundCheck2 = (Physics2D.OverlapBox(feet.position, new Vector2(0.25f, .5f), 0f, groundLayers) != null);
            }

            //Check if Space is released up before it reached the maximum jump height
            if(Input.GetButtonUp("Jump") && rb.velocity.y > 0) rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * jumpHeightReduce);
        }
    }

    /*void MovementAfterIceR(){
        float horizontalmove;
        horizontalmove = Input.GetAxisRaw("Horizontal");
        Debug.Log("horizontalmove right ice = " + horizontalmove);
        // PlayerMovement Method
        if(horizontalmove < 0){
            movementSpeed *= -1;
        }
    }

    void MovementAfterIceL(){
        float horizontalmove;
        horizontalmove = Input.GetAxisRaw("Horizontal");
        Debug.Log("horizontalmove left ice = " + horizontalmove);
        // PlayerMovement Method
        if(horizontalmove > 0){
            movementSpeed *= -1;
        }
    }*/

    // Collision detector
    private void OnCollisionStay2D(Collision2D col){
        // If collide turn onIce boolean to true
        if(col.gameObject.tag == "Ice"){
            onIce = true;
        // if collide with obstacle do something    
        }else if(col.gameObject.tag == "WallR"){
            Debug.Log("onRight = " + onRight);
            onRight = true;
            Debug.Log("onRight = " + onRight);
        }else if(col.gameObject.tag == "WallL"){
            Debug.Log("onLeft = " + onLeft);
            onLeft = true;
            Debug.Log("onLeft = " + onLeft);
        }else{
            onIce = false;
        }
  }

    //check for if touch ground
    public bool IsGrounded(){
        Collider2D groundCheck = Physics2D.OverlapBox(feet.position, new Vector2(3.5f, 1f), 0f, groundLayers);
        return (groundCheck != null && groundCheck2 != false);
  }
}

