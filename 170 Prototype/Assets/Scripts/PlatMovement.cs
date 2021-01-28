using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlatMovement : MonoBehaviour
{
    //rigid body is rigid body
    public Rigidbody2D rb;

    //enemy movement variable
    public int enemySpeed = 3;
    public int horizontalDirection;

    //condition and timer



    // Update is called once per frame
    void Update()
    {
        //comment out for raycast code, maybe needed for future movement
        /*RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(horizontalDirection, 0));*/

        rb.velocity = new Vector2(horizontalDirection * enemySpeed, rb.velocity.y);
        //rb.constraints = RigidbodyConstraints2D.FreezePositionY;


    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // if collide with Air Wall
        if (col.tag == "Air_Wall")
        {
            Flip();
        }

    }


    //turn the horizontal direction to the other way
    void Flip()
    {
        if (horizontalDirection > 0)
        {
            horizontalDirection = -1;
        }
        else
        {
            horizontalDirection = 1;
        }


    }


}
