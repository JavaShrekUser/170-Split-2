using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//for playtest purpose

public class SubLayerMove3 : MonoBehaviour
{
    public GameObject player;
    Rigidbody2D rb;
    public Camera cam;
    public GameObject subLayer1;
    public GameObject subLayer1Edge;
    public GameObject subLayer2;
    public GameObject subLayer2Edge;
    public GameObject subLayer3;
    public GameObject subLayer1Sprite1;
    public GameObject subLayer1Sprite2;
    public GameObject subLayer2Sprite1;
    public GameObject subLayer2Sprite2;

    public GameObject collectible;
    public GameObject collectible2;
    public GameObject collectible3;
    public GameObject dialogueBox;

    public GameObject ButtonCanvas;

    public AudioSource Starting;
    public AudioSource OpenMap;
    public AudioSource CloseMap;
    public AudioSource MoveRoom;
    public AudioSource PickUp;
    public AudioSource SomethingHappen; // pick up apple sound for now
    public AudioSource ChangeScene; // open door

    //for standing on platform alert use
    public bool colorChange = false;
    public int blinkTime = 5;
    public float blinkDuration = .25f;


    Vector3 mainScene = new Vector3(0, 0, 0);
    Vector3 subStart1;
    Vector3 subStart2;

    float move1 = 0f;
    float move2 = 0f;

    //Used for camera zoom in and out
    bool zoomOut = false;
    bool zoomIn = false;

    private int nextScene;//for playtest purpose
    private int lastScene;//for playtest purpose

    private void Start()
    {
      Starting.Play();
      rb = player.GetComponent<Rigidbody2D>();
      subStart1 = subLayer1.transform.position;
      subStart2 = subLayer2.transform.position;
      nextScene = SceneManager.GetActiveScene().buildIndex + 1;//for playtest purpose
      lastScene = SceneManager.GetActiveScene().buildIndex - 1;//for playtest purpose
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))//for playtest purpose
        {
            SceneManager.LoadScene(nextScene);//for playtest purpose
        }
        else if (Input.GetKeyDown(KeyCode.Q))//for playtest purpose
        {
            SceneManager.LoadScene(lastScene);//for playtest purpose
        }

        if(zoomOut){
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
        if (Input.GetButtonDown("ShowMap") && cam.orthographicSize == 10f && !dialogueBox.activeSelf)
        {
            OpenMap.Play();
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            zoomOut = true;

        }
        else if (cam.orthographicSize == 35f && Input.GetButtonDown("ShowMap") && !dialogueBox.activeSelf)
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
        if (subLayer1.transform.position == mainScene && subLayer2.transform.position == mainScene
          && subLayer1Sprite1.activeSelf &&  subLayer2Sprite2.GetComponent<SpriteRenderer>().sortingOrder == 3
          && subLayer1Sprite1.GetComponent<SpriteRenderer>().sortingOrder == 2)
        {
            subLayer1Sprite1.GetComponent<Animator>().SetTrigger("Active");
            subLayer1Sprite1.GetComponent<SpriteRenderer>().sortingOrder = 4;
        }
        if(subLayer1Sprite1.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
          subLayer1Sprite1.SetActive(false);
          subLayer2Sprite2.SetActive(false);

          collectible2.SetActive(true);
          collectible3.SetActive(true);
          collectible.SetActive(true);
          foreach (Transform t in collectible.transform) {
            t.GetComponent<SpriteRenderer>().sortingOrder = 3;
          }
          foreach (Transform x in collectible2.transform)
          {
              x.GetComponent<SpriteRenderer>().sortingOrder = 3;
          }
          foreach (Transform y in collectible3.transform)
          {
              y.GetComponent<SpriteRenderer>().sortingOrder = 3;
          }
        }

    }
    //new Movement code using mouse clicks
    public void MoveSubroom1(){
      if(cam.orthographicSize == 35f && !IsGrounded(subLayer1)){
        if(subLayer1.transform.position == mainScene)
        {
          MoveRoom.Play();
          move1 = -0.25f;
        }
        else
        {
          MoveRoom.Play();
          move1 = 0.25f;
          subLayer1Sprite1.GetComponent<SpriteRenderer>().sortingOrder = 3;
          subLayer1Sprite2.GetComponent<SpriteRenderer>().sortingOrder = 3;
          subLayer2Sprite1.GetComponent<SpriteRenderer>().sortingOrder = 2;
          subLayer2Sprite2.GetComponent<SpriteRenderer>().sortingOrder = 2;
        }
      }
      else if(subLayer1.transform.position == mainScene && IsGrounded(subLayer1)){
          //if standing on and try clicking, reset the blink timer
          blinkTime = 5;
          blinkDuration = .25f;
          colorChange = true;
      }
    }
  public void MoveSubroom2(){
    if(cam.orthographicSize == 35f && !IsGrounded(subLayer2)){
      if (subLayer2.transform.position == mainScene)
      {
          MoveRoom.Play();
          move2 = 0.25f;
      }
      else
      {
          MoveRoom.Play();
          move2 = -0.25f;
          subLayer2Sprite1.GetComponent<SpriteRenderer>().sortingOrder = 3;
          subLayer2Sprite2.GetComponent<SpriteRenderer>().sortingOrder = 3;
          subLayer1Sprite1.GetComponent<SpriteRenderer>().sortingOrder = 2;
          subLayer1Sprite2.GetComponent<SpriteRenderer>().sortingOrder = 2;
      }
    }
    else if(subLayer2.transform.position == mainScene && IsGrounded(subLayer2)){
          //if standing on and try clicking, reset the blink timer
          blinkTime = 5;
          blinkDuration = .25f;
          colorChange = true;
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
    }
    return false;
  }

}
