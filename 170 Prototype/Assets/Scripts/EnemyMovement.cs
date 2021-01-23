using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public Rigidbody2D rb;

    public int enemySpeed = 3;
    public int horizontalDirection;
    public bool isStun = false;
    public float stunTimer = 5f;

    // Update is called once per frame
    void Update()
    {
        //comment out for raycast code, maybe needed for future movement
        /*RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(horizontalDirection, 0));*/
            
        if(isStun == false)
        {
            rb.velocity = new Vector2(horizontalDirection * enemySpeed, rb.velocity.y);
        }
        else
        {

            stunTimer -= Time.deltaTime;

            rb.velocity = new Vector2(0, 0);

            if(stunTimer <= 0)
            {
                isStun = false;
                stunTimer = 5f;
            }

        }


            
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        // if collide with Air Wall
        if(col.tag == "Air_Wall"){
            Flip();
        }

        
        /*if(col.gameObject.layer == 10){

            Debug.Log("stunable");

        }*/

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
