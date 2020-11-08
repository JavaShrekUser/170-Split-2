using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubLayerMove2 : MonoBehaviour
{
    public Rigidbody2D rb;
    public Camera cam;
    public GameObject subLayer1;
    public GameObject subLayer2;
    public GameObject subLayer3;

    Vector3 mainScene = new Vector3(0,0,0);
    Vector3 subStart1;
    Vector3 subStart2;
    Vector3 subStart3;

    float move1 = 0f;
    float move2 = 0f;
    float move3 = 0f;

    private void Start()
    {
      subStart1 = subLayer1.transform.position;
      subStart2 = subLayer2.transform.position;
      subStart3 = subLayer3.transform.position;
    }
    // Update is called once per frame
    private void Update()
    {
      if(Input.GetButtonDown("ShowMap") && cam.orthographicSize == 10f){
        rb.constraints = RigidbodyConstraints2D.FreezePositionX;
        cam.orthographicSize = 35f;
      }
      else if(move1 != 0f)
      {
        subLayer1.transform.Translate(0,move1/2f,0);
        if(subLayer1.transform.position.y == mainScene.y || subLayer1.transform.position == subStart1){
          move1 = 0f;
        }
      }
      else if(move2 != 0f){
        subLayer2.transform.Translate(0,move2/2f,0);
        if(subLayer2.transform.position.y == mainScene.y || subLayer2.transform.position == subStart2){
          move2 = 0f;
        }
      }
      else if(move3 != 0f){
        subLayer3.transform.Translate(move3/2f,0,0);
        if(subLayer3.transform.position.x == mainScene.x || subLayer3.transform.position == subStart3){
          move3 = 0f;
        }
      }
      else if(cam.orthographicSize == 35f && Input.GetButtonDown("ShowMap")){
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        cam.orthographicSize = 10f;
      }
      else if(cam.orthographicSize == 35f){
        if(subLayer1.transform.position.y == mainScene.y && Input.GetKeyDown(KeyCode.C)){
          move1 = -0.25f;
        }
        else if(Input.GetKeyDown(KeyCode.C)){
          move1 = 0.25f;
        }
        if(subLayer2.transform.position.y == mainScene.y && Input.GetKeyDown(KeyCode.X)){
          move2 = 0.25f;
        }
        else if(Input.GetKeyDown(KeyCode.X)){
          move2 = -0.25f;
        }
        if(subLayer3.transform.position.x == mainScene.x && Input.GetKeyDown(KeyCode.Z)){
          move3 = 0.25f;
        }
        else if(Input.GetKeyDown(KeyCode.Z)){
          move3 = -0.25f;
        }
      }
    }
}