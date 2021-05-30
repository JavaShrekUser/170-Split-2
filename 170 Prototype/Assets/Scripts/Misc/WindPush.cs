using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindPush : MonoBehaviour
{
    public GameObject player;
    public float WindForce = 500f;
    Collider2D playerBox;
    Rigidbody2D rb;
    Collider2D windBox;
    void Start(){
      windBox = GetComponent<Collider2D>();
      rb = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
      playerBox = player.GetComponent<Collider2D>();
      if(windBox.IsTouching(playerBox) && !player.GetComponent<PlayerMovement>().IsGrounded()){
        GetComponent<AreaEffector2D>().forceMagnitude = WindForce;
        if(rb.velocity.y <= 0f){
          rb.gravityScale = 0f;
          rb.velocity = new Vector2(0, 0);
        }
        else{
          rb.velocity = new Vector2(0, rb.velocity.y);
        }
      }
      else{
        GetComponent<AreaEffector2D>().forceMagnitude = 0f;
        rb.gravityScale = 5f;
      }
    }
}
