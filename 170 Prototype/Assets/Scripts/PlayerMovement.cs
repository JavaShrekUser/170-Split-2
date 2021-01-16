﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
  //RigidBody
  public Rigidbody2D rb;

  //Horizontal Movement Variables
  [Range(0, 2)]
  public float movementSpeed = 1f;
  [Range(0, 1)]
  public float horizontalDampBasic = 0.3f;
  [Range(0, 1)]
  public float horizontalDampWhenStopping = 0.5f;
  [Range(0, 1)]
  public float horizontalDampWhenTurning = 0.5f;

  //Vertical Movement Variables
  public float jumpForce = 20f;
  [Range(0,1)]
  public float jumpHeightReduce = 0.5f;

  //Platform Collision Variables
  public Transform feet;
  public LayerMask groundLayers;
  public Collider2D player;
  public GameObject collectible;
  public GameObject collectible2;
  public GameObject collectible3;
  public GameObject dialogueBox;

  private void Start() {

    rb = GetComponent<Rigidbody2D>();

  }

  private void Update(){

    //Check if Space is pressed down and touching the ground at the same time
    if(Input.GetButtonDown("Jump") && IsGrounded()){
      rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
    //Check if Space is released up before it reached the maximum jump height
    if(Input.GetButtonUp("Jump") && rb.velocity.y > 0){
      rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * jumpHeightReduce);
    }

    //Check for collectable
    if (player.IsTouching(collectible.GetComponent<Collider2D>()))
    {
      collectible.SetActive(false);
    }
    if (player.IsTouching(collectible2.GetComponent<Collider2D>()))
    {
      collectible2.SetActive(false);
    }
    if (player.IsTouching(collectible3.GetComponent<Collider2D>()))
    {
      collectible3.SetActive(false);
      //rb.constraints = RigidbodyConstraints2D.FreezePositionX;
    }
  }

  private void OnTriggerEnter2D(Collider2D col){
    // if collide with trap
    if(col.tag == "Trap"){
      // reload the scene
      Scene scene;
      scene = SceneManager.GetActiveScene();
      SceneManager.LoadScene(scene.name);
    }

  }

  private void FixedUpdate() {

    float horizontalVelocity = rb.velocity.x * movementSpeed;
    horizontalVelocity += Input.GetAxisRaw("Horizontal");

    if(Mathf.Abs(Input.GetAxisRaw("Horizontal")) < 0.01f){
      horizontalVelocity *= Mathf.Pow(1f - horizontalDampWhenStopping, Time.deltaTime * 10f);
    }
    else if(Mathf.Sign(Input.GetAxisRaw("Horizontal")) != Mathf.Sign(horizontalVelocity)){
      horizontalVelocity *= Mathf.Pow(1f - horizontalDampWhenTurning, Time.deltaTime * 10f);
    }
    else{
      horizontalVelocity *= Mathf.Pow(1f - horizontalDampBasic, Time.deltaTime * 10f);
    }

    rb.velocity = new Vector2(horizontalVelocity, rb.velocity.y);
  }

  public bool IsGrounded(){
    Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.8f, groundLayers);

    return groundCheck != null;
  }

}
