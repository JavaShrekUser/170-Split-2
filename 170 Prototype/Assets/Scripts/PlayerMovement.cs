using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
  //RigidBody
  public Rigidbody2D rb;

  //Animation movements
  public Animator animator;

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
  private bool ceilCheck = false;
  public bool crouching = false;

  //Check Box Collider Use
  public BoxCollider2D stand;
  public BoxCollider2D crouch;

  //Platform Collision Variables
  public Transform feet;
  public Transform head;
  public LayerMask groundLayers;
  public Collider2D player;
  public bool stepOnEnemy = false;
  public GameObject dialogueBox;
  public GameObject collectible;
  public GameObject collectible2;
  public GameObject collectible3;
  private int collected = 0;
  private bool onIce = false;
  private float timeCheck = 0;
  private int jumpCount = 0;
  public Camera cam;
  //comment out for future need --- Access from playerMovement code to enemyMovement variable
  //public GameObject monster;
  //private EnemyMovement monsterCanMove;

  private void Start() {

    rb = GetComponent<Rigidbody2D>();

    //enable idle sprite
    stand.enabled = true;
    crouch.enabled = false;
    //comment out for future need --- Access from playerMovement code to enemyMovement variable
    //monsterCanMove = monster.GetComponent<EnemyMovement>();

  }

  private void Update(){
    //check for if crouch is pressed
    IsCrouching();

    //animation detection for if crouching
    animator.SetBool("crouchAnimation", crouching);

    //if so, change the collision mask
    if(crouching == true)
    {
      stand.enabled = false;
      crouch.enabled = true;
    }
    else
    {
      stand.enabled = true;
      crouch.enabled = false;
    }

    //Check if Space is pressed down and touching the ground at the same time
    print(timeCheck);
    if(jumpCount == 0 &&
      Input.GetButtonDown("Jump") && (IsGrounded() || stepOnEnemy || timeCheck < 0.4f) &&
      cam.orthographicSize == 10f &&
       !(rb.constraints == (RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation))){
      rb.velocity = new Vector2(rb.velocity.x, jumpForce);
      stepOnEnemy = false;
      jumpCount++;
      //comment out for future need --- Access from playerMovement code to enemyMovement variable
      //monsterCanMove.canMove = !(monsterCanMove.canMove);
    }
    //Check if Space is released up before it reached the maximum jump height
    if(Input.GetButtonUp("Jump") && rb.velocity.y > 0){
      rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * jumpHeightReduce);
    }

    if(IsGrounded())
    {
      timeCheck = 0;
      jumpCount = 0;
    }

    // //Check for collectable
    // if (player.IsTouching(collectible.GetComponent<Collider2D>()))
    // {
    //   collectible.SetActive(false);
    // }
    // if (player.IsTouching(collectible2.GetComponent<Collider2D>()))
    // {
    //   collectible2.SetActive(false);
    // }
    // if (player.IsTouching(collectible3.GetComponent<Collider2D>()))
    // {
    //   collectible3.SetActive(false);
    // }

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

    //check for if head hit the wall
    ceilCheck = Physics2D.OverlapBox(head.position, new Vector2(0.25f, .5f), 0f, groundLayers);


    //Time update for jump forgivness
    timeCheck += Time.fixedDeltaTime;
  }

  //check for if touch ground
  public bool IsGrounded(){
    Collider2D groundCheck = Physics2D.OverlapBox(feet.position, new Vector2(1f, 0.5f), 0f, groundLayers);
    return (groundCheck);
  }

  //check for if key pressing, cannot use get button up/down
  public void IsCrouching(){

    if(Input.GetAxisRaw("Crouch") != 0){
      crouching = true;
    }
    else if(Input.GetAxisRaw("Crouch") == 0 && ceilCheck == false){
      crouching = false;
    }

  }


}
