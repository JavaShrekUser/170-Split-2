using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlatMovement : MonoBehaviour
{
    //rigid body is rigid body
    public Rigidbody2D rb;

    //enemy movement variable
    public float moveSpeed = 3;
    public int horizontalDirection = 1;
    public float rightlimit = 13f;
    public float leftlimit = -1f;
    public float edgelimit;
    private float move = 0f;
    private float savem;


    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(move,0,0);
        if(rb.constraints == RigidbodyConstraints2D.FreezeAll){
          move = 0f;
          return;
        }
        if (transform.position.x >= rightlimit)
        {
            move = -moveSpeed;
            savem = move;
        }
        else if (transform.position.x <= leftlimit)
        {
            move = moveSpeed;
            savem = move;
        }
        else if(move == 0f)
        {
          move = savem;
          if(move == 0f){
            move = moveSpeed;
          }
        }


    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.tag == "Player" || col.collider.tag == "Enemy")
        {
          col.collider.GetComponent<Collider2D>().transform.SetParent(transform);
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if(col.collider.tag == "Player" || col.collider.tag == "Enemy")
        {
          col.collider.GetComponent<Collider2D>().transform.SetParent(null);
        }
    }

}
