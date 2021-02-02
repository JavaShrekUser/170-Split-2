using System.Collections;
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
    public bool isHarmful = true;

    //hitbox for collision
    public Transform head;
    public LayerMask stunCollide;
    public bool collisionCheck;
    

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

            isHarmful = false;

            //reactive all the condition and refresh timer once going out the state
            if(stunTimer <= 0)
            {
                isStun = false;
                stunTimer = 5f;
                isHarmful = true;
            }

        }

        //check of monster "head" colliding with player
        collisionCheck = Physics2D.OverlapBox(head.position, new Vector2(0.9f, .5f), 0f, stunCollide);
        //stun condition met
        if(collisionCheck == true)
        {
            isStun = true;
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
    // actual colliding event
    void OnCollisionEnter2D(Collision2D col) 
    {
        
        if(col.gameObject.name == "Player" && isHarmful == true && collisionCheck == false)
        {

            // reload the scene
            Scene scene;
            scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);

        }

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
