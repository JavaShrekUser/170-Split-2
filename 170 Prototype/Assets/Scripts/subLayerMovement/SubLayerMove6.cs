using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//for playtest purpose

public class SubLayerMove6 : MonoBehaviour
{
    public GameObject player;
    Rigidbody2D rb;
    public Camera cam;
    public GameObject subLayer1;
    public GameObject subLayer1Edge;
    public GameObject subLayer2;
    public GameObject subLayer2Edge;
    public GameObject ButtonCanvas;

    //for standing on platform alert use
    public bool colorChange = false;
    public int blinkTime = 5;
    public float blinkDuration = .25f;

    Vector3 mainScene = new Vector3(0, 0, 0);
    Vector3 subStart1;
    Vector3 subStart2;
    Vector2 saveVelocity;

    public AudioSource Starting;
    public AudioSource OpenMap;
    public AudioSource CloseMap;
    public AudioSource MoveRoom;
    public AudioSource PickUp;

    float move1 = 0f;
    float move2 = 0f;
    bool zoomOut = false;
    bool zoomIn = false;

    private int nextScene;//for playtest purpose
    private int lastScene;//for playtest purpose

    private bool onIce = false; //check if player is on Ice for movement purposes

    private void Start()//for playtest purpose
    {
        //Starting.Play();
        nextScene = SceneManager.GetActiveScene().buildIndex + 1;//for playtest purpose
        lastScene = SceneManager.GetActiveScene().buildIndex - 1;//for playtest purpose
        rb = player.GetComponent<Rigidbody2D>();
        subStart1 = subLayer1.transform.position;
        subStart2 = subLayer2.transform.position;

      }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))//for playtest purpose
        {
            SceneManager.LoadScene(nextScene);//for playtest purpose
        }
        else if (Input.GetKeyDown(KeyCode.J))//for playtest purpose
        {
            SceneManager.LoadScene(lastScene);//for playtest purpose
        }
        if (zoomOut){
          if(cam.orthographicSize == 35f){
            ButtonCanvas.SetActive(true);
            zoomOut = false;
          }
          else{
            cam.orthographicSize += 0.5f;
          }
        }
        else if(zoomIn){
          if(cam.orthographicSize == 10f){
            zoomIn = false;
          }
          else{
            ButtonCanvas.SetActive(false);
            cam.orthographicSize -= 0.5f;
          }
        }

        if (Input.GetButtonDown("ShowMap") && cam.orthographicSize == 10f)
        {
            OpenMap.Play();
            saveVelocity = rb.velocity;
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            rb.velocity = saveVelocity;
            zoomOut = true;


        }
        else if (cam.orthographicSize == 35f && Input.GetButtonDown("ShowMap"))
        {
            CloseMap.Play();
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            zoomIn = true;


        }
        if (move1 != 0f)
        {
            subLayer1.transform.Translate(0, move1 / 2f, 0);
            subLayer1Edge.transform.Translate(0,move1/2f,0);
            if (subLayer1.transform.position == mainScene || subLayer1.transform.position == subStart1)
            {
                move1 = 0f;
                MoveRoom.Stop();
            }
        }
        if (move2 != 0f)
        {
            subLayer2.transform.Translate(0, move2 / 2f, 0);
            subLayer2Edge.transform.Translate(0,move2/2f,0);
            if (subLayer2.transform.position == mainScene || subLayer2.transform.position == subStart2)
            {
                move2 = 0f;
                MoveRoom.Stop();
            }
        }
    }
    public void MoveSubroom1()
    {
        if (cam.orthographicSize == 35f)
        {
            if (subLayer1.transform.position == mainScene && !IsGrounded(subLayer1))
            {
                MoveRoom.Play();
                move1 = -0.25f;
            }
            else if(subLayer1.transform.position == subStart1)
            {
                MoveRoom.Play();
                move1 = 0.25f;
            }
            else if (subLayer1.transform.position == mainScene && IsGrounded(subLayer1))
            {
                //if standing on and try clicking, reset the blink timer
                blinkTime = 5;
                blinkDuration = .25f;
                colorChange = true;
            }
        }
    }
    public void MoveSubroom2()
    {
        if (cam.orthographicSize == 35f)
        {
            if (subLayer2.transform.position == mainScene && !IsGrounded(subLayer2))
            {
                MoveRoom.Play();
                move2 = 0.25f;
            }
            else if(subLayer2.transform.position == subStart2)
            {
                MoveRoom.Play();
                move2 = -0.25f;
            }
            else if (subLayer2.transform.position == mainScene && IsGrounded(subLayer2))
            {
                //if standing on and try clicking, reset the blink timer
                blinkTime = 5;
                blinkDuration = .25f;
                colorChange = true;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D col) {

      // If collide turn onIce boolean to true
      if(col.gameObject.tag == "Ice"){
        onIce = true;
      }
      else{
        onIce = false;
      }

    }
    public bool IsGrounded(GameObject subLayer){
      Collider2D playerCol = player.GetComponent<Collider2D>();
      foreach (Transform t in subLayer.transform){
        if(t.GetComponent<EdgeCollider2D>()){
          if(Physics2D.IsTouching(t.GetComponent<EdgeCollider2D>(), playerCol)) {
            return true;
          }
        }
        if(t.GetComponent<BoxCollider2D>()){
          if(Physics2D.IsTouching(t.GetComponent<BoxCollider2D>(), playerCol)) {
            return true;
          }
      }
    }
    return false;
  }
}
