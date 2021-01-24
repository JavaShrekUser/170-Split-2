using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Controller : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public bool touchIce;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement(){
        float horizontalmove;
        horizontalmove = Input.GetAxis("Horizontal");
        touchIce = false;

        if(horizontalmove != 0&&!touchIce){
            Debug.Log("Not on ice");
            rb.velocity = new Vector2(horizontalmove * speed, rb.velocity.y);
        }else{
            Debug.Log("On ice");
            rb.velocity = new Vector2(speed, -10);
        }
    }

    private void OnCollisionEnter2D(Collision2D col){
        // if collide with ice
        if(col.gameObject.tag == "Ice"){
            Debug.Log("Collision detected"+touchIce);
            rb.velocity = new Vector2(speed, -10);
            touchIce = true;
            Debug.Log("touchIce status = "+touchIce);
        }
  }
}
