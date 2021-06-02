using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//for playtest purpose

public class SubLayerMove4 : MonoBehaviour
{
    public GameObject player;
    Rigidbody2D rb;
    public Camera cam;
    public GameObject subLayer1;
    public GameObject subLayer2;
    public GameObject subLayer3;

    public GameObject ButtonCanvas;

    Vector3 mainScene = new Vector3(0, 0, 0);
    Vector3 subStart1;
    Vector3 subStart2;
    Vector3 subStart3;

    public AudioSource Starting;
    public AudioSource OpenMap;
    public AudioSource CloseMap;
    public AudioSource MoveRoom;
    public AudioSource PickUp;
    public AudioSource wind; //


    float move1 = 0f;
    float move2 = 0f;
    float move3 = 0f;

    private int nextScene;//for playtest purpose
    private int lastScene;//for playtest purpose

    private void Start()
    {
        //Starting.Play();
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

        if (Input.GetButtonDown("ShowMap") && cam.orthographicSize == 10f)
        {
            OpenMap.Play();
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            cam.orthographicSize = 35f;
            ButtonCanvas.SetActive(true);
        }
        else if (cam.orthographicSize == 35f && Input.GetButtonDown("ShowMap"))
        {
            CloseMap.Play();
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            cam.orthographicSize = 10f;
            ButtonCanvas.SetActive(false);
        }
        if (move1 != 0f)
        {
            subLayer1.transform.Translate(0, move1 / 2f, 0);
            if (subLayer1.transform.position.y == mainScene.y || subLayer1.transform.position == subStart1)
            {
                move1 = 0f;
                MoveRoom.Stop();
            }
        }
        if (move2 != 0f)
        {
            subLayer2.transform.Translate(0, move2 / 2f, 0);
            if (subLayer2.transform.position.y == mainScene.y || subLayer2.transform.position == subStart2)
            {
                move2 = 0f;
                MoveRoom.Stop();
            }
        }
        if (move3 != 0f)
        {
            subLayer3.transform.Translate(move3 / 2f, 0, 0);
            if (subLayer3.transform.position.x == mainScene.x || subLayer3.transform.position == subStart3)
            {
                move3 = 0f;
                MoveRoom.Stop();
            }
        }
        // else if (cam.orthographicSize == 35f)
        // {
        //     if (subLayer1.transform.position.y == mainScene.y && Input.GetKeyDown(KeyCode.C))
        //     {
        //         move1 = -0.25f;
        //     }
        //     else if (Input.GetKeyDown(KeyCode.C))
        //     {
        //         move1 = 0.25f;
        //     }
        //     if (subLayer2.transform.position.y == mainScene.y && Input.GetKeyDown(KeyCode.X))
        //     {
        //         move2 = 0.25f;
        //     }
        //     else if (Input.GetKeyDown(KeyCode.X))
        //     {
        //         move2 = -0.25f;
        //     }
        //     if (subLayer3.transform.position.x == mainScene.x && Input.GetKeyDown(KeyCode.Z))
        //     {
        //         move3 = 0.25f;
        //     }
        //     else if (Input.GetKeyDown(KeyCode.Z))
        //     {
        //         move3 = -0.25f;
        //     }
        // }
    }
    public void MoveSubroom1(){
      if(cam.orthographicSize == 35f){
        if(subLayer1.transform.position == mainScene && !IsGrounded(subLayer1)){
          MoveRoom.Play();
          wind.Stop();
          move1 = -0.25f;
        }
        else if(subLayer1.transform.position == subStart1){
          MoveRoom.Play();
          wind.Play();
          move1 = 0.25f;
        }
      }
    }
    public void MoveSubroom2(){
      if(cam.orthographicSize == 35f){
        if(subLayer2.transform.position == mainScene && !IsGrounded(subLayer2)){
          MoveRoom.Play();
          wind.Stop();
          move2 = 0.25f;
        }
        else if(subLayer2.transform.position == subStart2){
          MoveRoom.Play();
          wind.Play();
          move2 = -0.25f;
        }
      }
    }
    public void MoveSubroom3(){
      if(cam.orthographicSize == 35f){
        if(subLayer3.transform.position == mainScene && !IsGrounded(subLayer3)){
          MoveRoom.Play();
          wind.Stop();
          move3 = 0.25f;
        }
        else if(subLayer3.transform.position == subStart3){
          MoveRoom.Play();
          wind.Play();
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
        if(t.GetComponent<BoxCollider2D>()){
          if(Physics2D.IsTouching(t.GetComponent<BoxCollider2D>(), playerCol)) {
            return true;
          }
      }
    }
    return false;
  }
}
