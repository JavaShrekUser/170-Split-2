using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindPushLR : MonoBehaviour
{
    public GameObject player;
    public float WindForce = 500f;
    Collider2D playerBox;
    Rigidbody2D rb;
    Collider2D windBox;
    float flip = 1;
    void Start(){
      windBox = GetComponent<Collider2D>();
      rb = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
      if(GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Wait2")){
        flip = -1;
      }
      else if(GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Wait")){
        flip = 1;
      }
      playerBox = player.GetComponent<Collider2D>();
      if(windBox.IsTouching(playerBox) && !player.GetComponent<PlayerMovement>().IsGrounded()){
        GetComponent<AreaEffector2D>().forceMagnitude = WindForce * flip;
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
