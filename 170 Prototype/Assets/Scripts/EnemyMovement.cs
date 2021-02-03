﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    //rigid body is rigid body
    public Rigidbody2D rb;

    //enemy movement variable
    public int enemySpeed = 3;
    public int horizontalDirection;

    //condition and timer
    public bool isStun = false;
    public float stunTimer = 5f;

    //hitbox for collision
    public Transform head;
    public Transform leftHand;
    public Transform rightHand;
    public LayerMask playerCheck;
    public bool headHitFeet;
    public float headSize = 0.8f;
    public bool harmPlayerLeft;
    public bool harmPlayerRight;
    public float harmSize = 0.8f;
    

    // Update is called once per frame
    void Update()
    {
        //what to do if the monster is not stunned
        if(isStun == false)
        {
            rb.velocity = new Vector2(horizontalDirection * enemySpeed, rb.velocity.y);
        }
        else //what if it's in stunned state
        {

            stunTimer -= Time.deltaTime;

            rb.velocity = new Vector2(0, rb.velocity.y);

            //reactive all the condition and refresh timer once going out the state
            if(stunTimer <= 0)
            {
                isStun = false;
                stunTimer = 5f;

            }

        }

        //check of monster "head" colliding with player
        headHitFeet = Physics2D.OverlapBox(head.position, new Vector2(headSize, .5f), 0f, playerCheck);
        //stun condition met
        if(headHitFeet == true)
        {
            isStun = true;
        }

        harmPlayerLeft = Physics2D.OverlapBox(leftHand.position, new Vector2(.5f, harmSize), 0f, playerCheck);

        if(harmPlayerLeft == true && isStun == false)
        {
            killPlayer();
        }

        harmPlayerRight = Physics2D.OverlapBox(rightHand.position, new Vector2(.5f, harmSize), 0f, playerCheck);

        if(harmPlayerRight == true && isStun == false)
        {
            killPlayer();
        }

            
    }
    // trigger event
    void OnTriggerEnter2D(Collider2D col)
    {
        // if collide with Air Wall
        if(col.tag == "Air_Wall"){
            Flip();
        }

    }

    void killPlayer()
    {

        // reload the scene
            Scene scene;
            scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);


    }

    //turn the horizontal direction to the other way
    void Flip()
    {
        if(horizontalDirection > 0)
        {
            horizontalDirection = -1;
        }
        else
        {
            horizontalDirection = 1;
        }


    }

}
