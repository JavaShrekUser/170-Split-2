using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
  //RigidBody
  public SpriteRenderer sr;
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
  bool isMoving = false;

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

  // Checkpoint variables
  // Respawn positions
  public Transform respawnPoint1;
  public Transform respawnPoint2;
  public Transform respawnPoint3;
  private int checkPointActive = 0;

  public AudioSource Jumping;
  public AudioSource WalkGress;

  public AudioSource PickUp;
  public AudioSource StepOnMonsta;
  public AudioSource hitIceSound;


  private void Start() {

    rb = GetComponent<Rigidbody2D>();
    WalkGress = GetComponent<AudioSource>();

    //enable idle sprite
    stand.enabled = true;
    crouch.enabled = false;


    //comment out for future need --- Access from playerMovement code to enemyMovement variable
    //monsterCanMove = monster.GetComponent<EnemyMovement>();

  }



  private void Update(){
    //check for if crouch is pressed
    IsCrouching();

    if (rb.velocity.x != 0){
      isMoving = true;
    }else{
      isMoving = false;
    }

    if (isMoving){
      if (!WalkGress.isPlaying){
        WalkGress.Play();
      }else{
        WalkGress.Stop();
      }
    }

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
    if(jumpCount == 0 &&
      Input.GetButtonDown("Jump") && (IsGrounded() || stepOnEnemy || timeCheck < 0.2f) &&
      cam.orthographicSize == 10f &&
       !(rb.constraints == (RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation))){
      ++jumpCount;
      rb.velocity = new Vector2(rb.velocity.x, jumpForce);
      Jumping.Play();
      stepOnEnemy = false;
      //comment out for future need --- Access from playerMovement code to enemyMovement variable
      //monsterCanMove.canMove = !(monsterCanMove.canMove);
    }
    if(IsGrounded() && timeCheck > 0.1f)
    {
      timeCheck = 0;
      jumpCount = 0;
      onIce = IsIce();
    }
    //Check if Space is released up before it reached the maximum jump height
    if(Input.GetButtonUp("Jump") && rb.velocity.y > 0){
      rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * jumpHeightReduce);
      //Jumping.Play();
    }



    // //Check for collectable
     if (player.IsTouching(collectible.GetComponent<Collider2D>()))
     {
       PickUp.Play();
       collectible.SetActive(false);
     }
     if (player.IsTouching(collectible2.GetComponent<Collider2D>()))
     {
       PickUp.Play();
       collectible2.SetActive(false);
     }
     if (player.IsTouching(collectible3.GetComponent<Collider2D>()))
     {
       PickUp.Play();
       collectible3.SetActive(false);
     }

  }


  private void OnTriggerEnter2D(Collider2D col){
    // testing which check point player last saved
    if(col.tag == "checkP1") checkPointActive = 1;
    if(col.tag == "checkP2") checkPointActive = 2;
    if(col.tag == "checkP3") checkPointActive = 3;

    // if collide with trap
    if(col.tag == "Trap"){
      Debug.Log("CPA = "+ checkPointActive);
      if(checkPointActive == 0 || respawnPoint1 == null){
        // if no checkpoint activated
        // reload the scene when dead
        Scene scene;
        scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
      }else if(checkPointActive == 1){    // respawn to the lastest saved check point
        Instantiate(this.gameObject, respawnPoint1.position, Quaternion.identity);
      }else if(checkPointActive == 2){
        Instantiate(this.gameObject, respawnPoint2.position, Quaternion.identity);
      }else if(checkPointActive == 3){
        Instantiate(this.gameObject, respawnPoint3.position, Quaternion.identity);
      }
    }

  }

  private void OnCollisionEnter2D(Collision2D col) {

    //check if colliding with object tagged with "Enemy"
    if(col.gameObject.tag == "Enemy"){
      StepOnMonsta.Play();
      stepOnEnemy = true;
    }
    if(col.gameObject.tag != "Ice"){
      onIce = false;
    }
    if(col.gameObject.tag == "Ice"){
      hitIceSound.Play();
    }
    if(col.gameObject.tag == "Enemy") Debug.Log("touching enemy test");
  }

  private void FixedUpdate() {

    //normal x movement setting
    float horizontalVelocity = rb.velocity.x * movementSpeed;
    horizontalVelocity += Input.GetAxisRaw("Horizontal");

    if(horizontalVelocity < 0 && cam.orthographicSize == 10f)
      sr.flipX = false;
    else if(horizontalVelocity > 0 && cam.orthographicSize == 10f)
      sr.flipX = true;
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
      if(rb.velocity.x >= 10f){
        horizontalVelocity = 10f;
      }
      else if(rb.velocity.x <= -10f){
        horizontalVelocity = -10f;
      }
      else if(rb.velocity.x > 0.5f){
        horizontalVelocity = rb.velocity.x + Time.deltaTime * 5f;
      }
      else if(rb.velocity.x < -0.5f){
        horizontalVelocity = rb.velocity.x - Time.deltaTime * 5f;
      }
      else{
        horizontalVelocity = Input.GetAxisRaw("Horizontal");
      }
      rb.velocity = new Vector2(horizontalVelocity, rb.velocity.y);
    }
    else{
      rb.velocity = new Vector2(horizontalVelocity, rb.velocity.y);
    }

    //check for if head hit the wall
    ceilCheck = Physics2D.OverlapBox(head.position, new Vector2(0.25f, .5f), 0f, groundLayers);


    //Time update for jump forgivness
    timeCheck += Time.fixedDeltaTime;
  }

  //check for if touch ground
  public bool IsGrounded(){
    Collider2D groundCheck = Physics2D.OverlapBox(feet.position, new Vector2(0.5f, 0.25f), 0f, groundLayers);
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

  public bool IsIce(){
    foreach(GameObject g in (GameObject.FindGameObjectsWithTag("Ice"))) {
      if(!g.GetComponent<EdgeCollider2D>()){
        return false;
      }
      if(stand.IsTouching(g.GetComponent<EdgeCollider2D>())){
        return true;
      }
      if(crouch.IsTouching(g.GetComponent<EdgeCollider2D>())){
        return true;
      }
    }
    return false;
  }



}
