using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    //rigid body is rigid body
    public Rigidbody2D rb;
    public GameObject Lwall;
    public GameObject dubplat;
    public GameObject ghost;

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
    public Transform feet;
    public LayerMask playerCheck;
    public bool headHitFeet;
    public float headSize = 0.8f;
    public bool harmPlayerLeft;
    public bool harmPlayerRight;
    public float harmSize = 0.8f;
    public LayerMask groundLayers;

    float timeCheck;

    private void Start()
    {
        Lwall.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if(nearEdge() && timeCheck > 0.2f)
        {
          timeCheck = 0;
          Flip();
        }
        //check of monster "head" colliding with the ground layers to flip
        if(timeCheck > 0.2f && rb.velocity.magnitude < 0.5) {
          Flip();
          timeCheck = 0;
        }
        timeCheck += Time.deltaTime;
        //what to do if the monster is not stunned
        if(isStun == false)
        {
            rb.constraints = RigidbodyConstraints2D.None;
            rb.velocity = new Vector2(horizontalDirection * enemySpeed, rb.velocity.y);
        }
        else //what if it's in stunned state
        {

            stunTimer -= Time.deltaTime;

            //reactive all the condition and refresh timer once going out the state
            if(stunTimer <= 0)
            {
                isStun = false;
                stunTimer = 5f;

            }

        }

        //check of monster "head" colliding with player
        headHitFeet = Physics2D.OverlapBox(head.position, new Vector2(headSize, .85f), 0f, playerCheck);
        //stun condition met
        if(headHitFeet == true)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
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
        if(col.tag == "Air_Wall")
        {
            Flip();
        }

        // if enemy falls down into the lava
        if(col.tag == "Trap"){
            killPlayer();
        }

        if (col.tag == "speair")
        {
            Flip();
        }

        if (col.tag == "speair2")
        {
            Flip();
            Lwall.SetActive(true);
        }

        if (col.tag == "Switch")
        {

            dubplat.SetActive(false);
            ghost.SetActive(false);
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
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            horizontalDirection = 1;
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    public bool nearEdge(){
      Vector3 temp = feet.position;
      temp.x = feet.position.x - 0.65f;
      Collider2D groundCheckLeft = Physics2D.OverlapBox(temp, new Vector2(0.2f, 2f), 0f, groundLayers);
      temp.x = feet.position.x + 0.65f;
      Collider2D groundCheckRight = Physics2D.OverlapBox(temp, new Vector2(0.2f, 2f), 0f, groundLayers);
      return (!groundCheckLeft || !groundCheckRight);
    }

}
