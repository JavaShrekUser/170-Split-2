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

  public AudioSource Starting;
  public AudioClip Loop;

  [Range(0, 1)]
  public float volume_slider = 0.5f;

  //Horizontal Movement Variables
  [Range(0, 2)]
  public float movementSpeed = 1f;
  [Range(0, 1)]
  public float horizontalDampBasic = 0.3f;
  [Range(0, 1)]
  public float horizontalDampWhenStopping = 0.5f;
  [Range(0, 1)]
  public float horizontalDampWhenTurning = 0.5f;
  bool movingNow = false;

  //Vertical Movement Variables
  public float jumpForce = 20f;
  [Range(0,1)]
  public float jumpHeightReduce = 0.5f;
  public bool ceilCheck = false;
  public bool crouching = false;
  bool isMoving = false;
  bool mapOpening = false;

  //Check Box Collider Use
  public CircleCollider2D stand;
  public CircleCollider2D crouch;

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
  public AudioSource WalkGrass;

  public AudioSource PickUp;
  public AudioSource StepOnMonsta;
  public AudioSource hitIceSound;
  public AudioSource OpenDoor;
  public AudioSource ButtonPress;
  public AudioSource IceCrack;

  private void Start() {

    //Starting.Play();
    rb = GetComponent<Rigidbody2D>();
    //WalkGrass = GetComponent<AudioSource>();

    //enable idle sprite
    stand.enabled = true;
    crouch.enabled = false;


    //comment out for future need --- Access from playerMovement code to enemyMovement variable
    //monsterCanMove = monster.GetComponent<EnemyMovement>();

  }



  private void Update(){
    //Starting.volume = volume_slider;

    //if (!Starting.isPlaying)
    //{
       //Starting.clip = Loop;
       //Starting.loop = true;
       //Starting.Play();
    //}
    //check for if crouch is pressed
    IsCrouching();

    //check for map open
    mapOpened();

    //animation detection for if map is opening
    animator.SetBool("mapIsOpen", mapOpening);

    //animation detection for if crouching
    animator.SetBool("crouchAnimation", crouching);

    //animation detection for if moving
    animator.SetBool("movingAnimation", movingNow);

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
    //*************************************************************************************************************

    if (isMoving){
      if (!WalkGrass.isPlaying){
        WalkGrass.Play();
      }else{
        WalkGrass.Stop();
      }
    }
    //***************************************************************************************************************

    if(Input.GetAxisRaw("Horizontal") != 0)
    {
      movingNow = true;
    }
    else
    {
      movingNow = false;
      WalkGrass.Stop();
    }

    if (movingNow)
        {
      if (!WalkGrass.isPlaying){
        WalkGrass.Play();
      }
      if (!IsGrounded())
            {
                WalkGrass.Stop();
            }
    }

    //Check if Space is pressed down and touching the ground at the same time
    if((stepOnEnemy || jumpCount == 0) && IsGrounded() &&
      Input.GetButtonDown("Jump") && cam.orthographicSize == 10f &&
       !(rb.constraints == (RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation))){
      ++jumpCount;
      rb.velocity = new Vector2(rb.velocity.x, jumpForce);
      //Jumping.pitch *= Random.Range(0.9f, 1.1f);
      Jumping.Play();
      stepOnEnemy = false;
      //comment out for future need --- Access from playerMovement code to enemyMovement variable
      //monsterCanMove.canMove = !(monsterCanMove.canMove);
    }
    if(IsGrounded() && timeCheck > 0.2f)
    {
      timeCheck = 0;
      jumpCount = 0;
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


    if(col.tag == "Collect"){
      PickUp.Play();
    }

    if(col.tag == "Switch"){
      ButtonPress.Play();
    }



    // if collide with trap
    if(col.tag == "Trap"){
      Debug.Log("CPA = "+ checkPointActive);
      //if(checkPointActive == 0 || respawnPoint1 == null){
        // if no checkpoint activated
        // reload the scene when dead
        Scene scene;
        scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
      // }else if(checkPointActive == 1){    // respawn to the lastest saved check point
      //   Instantiate(this.gameObject, respawnPoint1.position, Quaternion.identity);
      // }else if(checkPointActive == 2){
      //   Instantiate(this.gameObject, respawnPoint2.position, Quaternion.identity);
      // }else if(checkPointActive == 3){
      //   Instantiate(this.gameObject, respawnPoint3.position, Quaternion.identity);
      // }
    }

  }

  private void OnCollisionEnter2D(Collision2D col) {

    //check if colliding with object tagged with "Enemy"
    if(col.gameObject.tag == "Enemy"){
      StepOnMonsta.Play();
      stepOnEnemy = true;
    }else if(IsGrounded()){
      onIce = false;
    }
    if(col.gameObject.tag == "Enemy") Debug.Log("touching enemy test");

    if(col.gameObject.tag == "Ice"){
      hitIceSound.Play();
    }
  }
  void OnCollisionStay2D(Collision2D col)
  {
    if(col.gameObject.tag == "Ice" || col.gameObject.tag == "ICE"){
      onIce = true;
    }
  }

  private void FixedUpdate() {

    //normal x movement setting
    float horizontalVelocity = rb.velocity.x * movementSpeed;
    horizontalVelocity += Input.GetAxisRaw("Horizontal");

    //character turning sprite facing & turning damping
    if(Input.GetAxisRaw("Horizontal") < 0 && cam.orthographicSize == 10f)
      sr.flipX = false;
    else if(Input.GetAxisRaw("Horizontal") > 0 && cam.orthographicSize == 10f)
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

    if(onIce && cam.orthographicSize == 10f){
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
      print("not on ice");
      rb.velocity = new Vector2(horizontalVelocity, rb.velocity.y);
    }

    //check for if head hit the wall
    ceilCheck = Physics2D.OverlapBox(head.position, new Vector2(0.25f, .5f), 0f, groundLayers);


    //Time update for jump forgivness
    timeCheck += Time.fixedDeltaTime;
  }

  //check for if touch ground
  public bool IsGrounded(){
    Collider2D groundCheck = Physics2D.OverlapBox(feet.position, new Vector2(1f, 1f), 0f, groundLayers);
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

  //check if the map is opened up
  public void mapOpened()
  {
    if(rb.constraints == (RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation))
    {
      mapOpening = true;
    }
    else{
      mapOpening = false;
    }


  }





}
