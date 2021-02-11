using System.Collections;
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
  private bool groundCheck2 = true;

  //Platform Collision Variables
  public Transform feet;
  public LayerMask groundLayers;
  public Collider2D player;
  public bool stepOnEnemy = false;
  public GameObject dialogueBox;
  public GameObject collectible;
  public GameObject collectible2;
  public GameObject collectible3;
  private int collected = 0;
  private bool onIce = false;

  //comment out for future need --- Access from playerMovement code to enemyMovement variable
  //public GameObject monster;
  //private EnemyMovement monsterCanMove;

  private void Start() {

    rb = GetComponent<Rigidbody2D>();

    //comment out for future need --- Access from playerMovement code to enemyMovement variable
    //monsterCanMove = monster.GetComponent<EnemyMovement>();

  }

  private void Update(){

    //Check if Space is pressed down and touching the ground at the same time
    if(Input.GetButtonDown("Jump") && (IsGrounded() || stepOnEnemy)){
      rb.velocity = new Vector2(rb.velocity.x, jumpForce);
      groundCheck2 = false;
      stepOnEnemy = false;

      //comment out for future need --- Access from playerMovement code to enemyMovement variable
      //monsterCanMove.canMove = !(monsterCanMove.canMove);
    }
    else if(groundCheck2 == false){
      groundCheck2 = (Physics2D.OverlapBox(feet.position, new Vector2(0.25f, .5f), 0f, groundLayers) != null);
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

  private void OnCollisionEnter2D(Collision2D col) {

    //check if colliding with object tagged with "Enemy"
    if(col.gameObject.tag == "Enemy"){
      stepOnEnemy = true;
    }
    // If collide turn onIce boolean to true
    if(col.gameObject.tag == "Ice"){
      onIce = true;
    }
    else{
      onIce = false;
    }

  }

  private void FixedUpdate() {

    //normal x movement setting
    float horizontalVelocity = rb.velocity.x * movementSpeed;
    horizontalVelocity += Input.GetAxisRaw("Horizontal");

    //x movement with different damping conditions
    if(Mathf.Abs(Input.GetAxisRaw("Horizontal")) < 0.01f){
      horizontalVelocity *= Mathf.Pow(1f - horizontalDampWhenStopping, Time.deltaTime * 10f);
    }
    else if(Mathf.Sign(Input.GetAxisRaw("Horizontal")) != Mathf.Sign(horizontalVelocity)){
      horizontalVelocity *= Mathf.Pow(1f - horizontalDampWhenTurning, Time.deltaTime * 10f);
    }
    else{
      horizontalVelocity *= Mathf.Pow(1f - horizontalDampBasic, Time.deltaTime * 10f);
    }

    if(onIce){
      print(rb.velocity.x);
      if(rb.velocity.x >= 4.5f){
        horizontalVelocity = 4.5f;
      }
      else if(rb.velocity.x <= -4.5f){
        horizontalVelocity = -4.5f;
      }
      else{
        horizontalVelocity = rb.velocity.x;
      }
      rb.velocity = new Vector2(horizontalVelocity, rb.velocity.y);;
    }
    else{
      rb.velocity = new Vector2(horizontalVelocity, rb.velocity.y);;
    }
  }

  //check for if touch ground
  public bool IsGrounded(){
    Collider2D groundCheck = Physics2D.OverlapBox(feet.position, new Vector2(3.5f, 1f), 0f, groundLayers);

    return (groundCheck != null && groundCheck2 != false);
  }


}
