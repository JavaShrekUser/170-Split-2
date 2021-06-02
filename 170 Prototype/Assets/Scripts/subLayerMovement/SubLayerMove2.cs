using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//for playtest purpose

public class SubLayerMove2 : MonoBehaviour
{
    public GameObject player;
    public Camera mainCam;
    public Camera effectCam;
    public GameObject subLayer1;
    public GameObject subLayer2;
    public GameObject subLayer3;

    public GameObject ButtonCanvas;

    Vector3 mainScene = new Vector3(0,0,0);
    Vector3 subStart1;
    Vector3 subStart2;
    Vector3 subStart3;

    public AudioSource Starting;
    public AudioSource OpenMap;
    public AudioSource CloseMap;
    public AudioSource MoveRoom;
    public AudioSource PickUp;
    public AudioSource water; //
    public AudioSource lava; //

    float move1 = 0f;
    float move2 = 0f;
    float move3 = 0f;
    Rigidbody2D rb;

    private int nextScene;//for playtest purpose
    private int lastScene;//for playtest purpose

    private void Start()
    {
      //Starting.Play();
      //water.Play();
      //lava.Play();
      rb = player.GetComponent<Rigidbody2D>();
      subStart1 = subLayer1.transform.position;
      subStart2 = subLayer2.transform.position;
      subStart3 = subLayer3.transform.position;
      nextScene = SceneManager.GetActiveScene().buildIndex + 1;//for playtest purpose
      lastScene = SceneManager.GetActiveScene().buildIndex - 1;//for playtest purpose
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

        if (Input.GetKeyDown(KeyCode.M) && mainCam.orthographicSize == 10f){
        OpenMap.Play();
        rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        mainCam.orthographicSize = 35f;
        effectCam.orthographicSize = 35f;
        ButtonCanvas.SetActive(true);

      }
      else if(mainCam.orthographicSize == 35f && Input.GetKeyDown(KeyCode.M)){
        CloseMap.Play();
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        mainCam.orthographicSize = 10f;
        effectCam.orthographicSize = 10f;
        ButtonCanvas.SetActive(false);
      }
      if(move1 != 0f)
      {
        subLayer1.transform.Translate(0,move1/2f,0);
        if(subLayer1.transform.position.y == mainScene.y || subLayer1.transform.position == subStart1){
          move1 = 0f;
          MoveRoom.Stop();
        }
      }
      if(move2 != 0f){
        subLayer2.transform.Translate(0,move2/2f,0);
        if(subLayer2.transform.position.y == mainScene.y || subLayer2.transform.position == subStart2){
          move2 = 0f;
          MoveRoom.Stop();
        }
      }
      if(move3 != 0f){
        subLayer3.transform.Translate(move3/2f,0,0);
        if(subLayer3.transform.position.x == mainScene.x || subLayer3.transform.position == subStart3){
          move3 = 0f;
          MoveRoom.Stop();
        }
      }
  }
  public void MoveSubroom1(){
    if(mainCam.orthographicSize == 35f && !IsGrounded(subLayer1)){
      if(subLayer1.transform.position == mainScene){
        MoveRoom.Play();
        move1 = -0.25f;
      }
      else{
        MoveRoom.Play();
        move1 = 0.25f;
      }
    }
  }
  public void MoveSubroom2(){
    if(mainCam.orthographicSize == 35f && !IsGrounded(subLayer2)){
      if(subLayer2.transform.position == mainScene){
        MoveRoom.Play();
        lava.Play();
        move2 = 0.25f;
      }
      else{
        MoveRoom.Play();
        lava.Play();
        move2 = -0.25f;
      }
    }
  }
  public void MoveSubroom3(){
    if(mainCam.orthographicSize == 35f && !IsGrounded(subLayer3)){
      if(subLayer3.transform.position == mainScene){
        MoveRoom.Play();
        move3 = 0.25f;
      }
      else{
        MoveRoom.Play();
        move3 = -0.25f;
      }
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
