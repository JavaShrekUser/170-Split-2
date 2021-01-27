using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{

    public Rigidbody2D rb;

    public int enemySpeed = 3;
    public int horizontalDirection;
    public bool isStun = false;
    public bool isHarmful = true;
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

            isHarmful = false;

            if(stunTimer <= 0)
            {
                isStun = false;
                stunTimer = 5f;
                isHarmful = true;
            }

        }

        //EnemyRaycast();


            
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // if collide with Air Wall
        if(col.tag == "Air_Wall"){
            Flip();
        }

    }

    void OnCollisionEnter2D(Collision2D col) 
    {
        
        if(col.gameObject.name == "Player" && isHarmful == true)
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

    // void EnemyRaycast()
    // {

    //     Debug.Log();

    //     RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up);

    //     if(hit.collider.name == "Player")
    //     {
    //         Debug.Log("Touched player");
    //     }

    // }
}
