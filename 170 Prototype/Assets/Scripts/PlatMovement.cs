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
    public float rightlimit = 13f;
    public float leftlimit = -1f;
    public float edgelimit;
    private float move = 0f;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(move,0,0);
        if(rb.constraints == RigidbodyConstraints2D.FreezeAll){
          move = 0f;
          return;
        }
        if (transform.position.x >= rightlimit)
        {
            move = -0.01f;
        }
        else if (transform.position.x <= leftlimit)
        {
            move = 0.01f;
        }
        else if(move == 0f)
        {
          move = -0.01f;
        }


    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.tag == "Player")
        {
          col.collider.GetComponent<Collider2D>().transform.SetParent(transform);
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if(col.collider.tag == "Player")
        {
          col.collider.GetComponent<Collider2D>().transform.SetParent(null);
        }
    }

}
