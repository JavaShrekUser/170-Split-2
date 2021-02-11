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
    public GameObject LeftWall;
    public GameObject MidWall;
    public GameObject RightWall;
    public GameObject DoorPad;
    public GameObject LastWall;

    //condition and timer
    private void Start()
    {
        LeftWall.SetActive(true);
        MidWall.SetActive(true);
        RightWall.SetActive(false);
        LastWall.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        //comment out for raycast code, maybe needed for future movement
        /*RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(horizontalDirection, 0));*/

        rb.velocity = new Vector2(horizontalDirection * enemySpeed, rb.velocity.y);
        //rb.constraints = RigidbodyConstraints2D.FreezePositionY;
        if (!DoorPad.activeSelf)
        {
            LastWall.SetActive(true);
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // if collide with Air Wall
        if (col.tag == "Air_Wall")
        {
            Flip();
        }
        if (col.tag == "spetag")
        {
            LeftWall.SetActive(false);
            MidWall.SetActive(false);
            RightWall.SetActive(true);
        }
    }
    /*private void OnTrigger2D(Collider2D col)
    {
        if (col.tag == "spetag")
        {
            LeftWall.SetActive(false);
            
        }
    }*/


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
