using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlatMovement : MonoBehaviour
{
    //rigid body is rigid body
    public Rigidbody2D rb;

    //enemy movement variable
    public int moveSpeed = 3;
    public int horizontalDirection = 1;
    public GameObject LeftWall;
    public GameObject MidWall;
    //public GameObject RightWall;
    /*public GameObject DoorPad;
    public GameObject LastWall;*/
    public float rightlimit = 3f;
    public float leftlimit = -3f;
    public float edgelimit;


    //condition and timer
    private void Start()
    {
        /*LeftWall.SetActive(true);
        MidWall.SetActive(true);
        RightWall.SetActive(false);
        LastWall.SetActive(false);*/
        LeftWall.SetActive(true);
        //MidWall.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        //comment out for raycast code, maybe needed for future movement
        /*RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(horizontalDirection, 0));*/

        rb.velocity = new Vector2(horizontalDirection * moveSpeed, rb.velocity.y);

        /*if (!DoorPad.activeSelf)
        {
            LastWall.SetActive(true);
        }*/
        if (transform.position.x > rightlimit)
        {
            horizontalDirection = -1;
        }
        else if (transform.position.x < leftlimit)
        {
            horizontalDirection = 1;
        }

        if (transform.position.x > edgelimit)
        {
            MidWall.SetActive(false);
        }
        //rb.velocity = Vector3.right * horizontalDirection * moveSpeed * Time.deltaTime;
        //transform.Translate(rb.velocity);

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "spetag")
        {
            LeftWall.SetActive(false);
            MidWall.SetActive(false);
            //RightWall.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        LeftWall.SetActive(true);
        //MidWall.SetActive(true);

    }

}
