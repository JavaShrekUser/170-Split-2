using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//for playtest purpose

public class SubLayerMove3 : MonoBehaviour
{
    public Rigidbody2D rb;
    public Camera cam;
    public GameObject subLayer1;
    public GameObject subLayer2;
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


    Vector3 mainScene = new Vector3(0, 0, 0);
    Vector3 subStart1;
    Vector3 subStart2;

    float move1 = 0f;
    float move2 = 0f;

    private int nextScene;//for playtest purpose
    private int lastScene;//for playtest purpose

    private void Start()
    {
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

        if (Input.GetButtonDown("ShowMap") && cam.orthographicSize == 10f && !dialogueBox.activeSelf)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            cam.orthographicSize = 35f;
            ButtonCanvas.SetActive(true);

        }
        else if (cam.orthographicSize == 35f && Input.GetButtonDown("ShowMap") && !dialogueBox.activeSelf)
        {
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            cam.orthographicSize = 10f;
            ButtonCanvas.SetActive(false);
        }
        if (move1 != 0f)
        {
            subLayer1.transform.Translate(0, move1 / 2f, 0);
            if (subLayer1.transform.position == mainScene || subLayer1.transform.position == subStart1)
            {
                move1 = 0f;
            }
        }
        if (move2 != 0f)
        {
            subLayer2.transform.Translate(0, move2 / 2f, 0);
            if (subLayer2.transform.position == mainScene || subLayer2.transform.position == subStart2)
            {
                move2 = 0f;
            }
        }
        if (subLayer1.transform.position == mainScene && subLayer2.transform.position == mainScene
          && subLayer1Sprite1.activeSelf &&  subLayer2Sprite2.GetComponent<SpriteRenderer>().sortingOrder == 2
          && subLayer1Sprite1.GetComponent<SpriteRenderer>().sortingOrder == 1)
        {
            subLayer1Sprite1.SetActive(false);
            subLayer2Sprite2.SetActive(false);

            collectible2.SetActive(true);
            collectible3.SetActive(true);
            collectible.SetActive(true);
            foreach (Transform t in collectible.transform) {
              t.GetComponent<SpriteRenderer>().sortingOrder = 4;
            }
            foreach (Transform x in collectible2.transform)
            {
                x.GetComponent<SpriteRenderer>().sortingOrder = 1;
            }
            foreach (Transform y in collectible3.transform)
            {
                y.GetComponent<SpriteRenderer>().sortingOrder = 1;
            }
        }
        // Old movment script using key strokes
        //
        //
        // else if (cam.orthographicSize == 35f)
        // {
        //     if (subLayer1.transform.position == mainScene && Input.GetKeyDown(KeyCode.C))
        //     {
        //         move1 = -0.25f;
        //     }
        //     else if (Input.GetKeyDown(KeyCode.C) && (move1 == 0f))
        //     {
        //         move1 = 0.25f;
        //         subLayer1Sprite1.GetComponent<SpriteRenderer>().sortingOrder = 2;
        //         subLayer1Sprite2.GetComponent<SpriteRenderer>().sortingOrder = 2;
        //         subLayer2Sprite1.GetComponent<SpriteRenderer>().sortingOrder = 1;
        //         subLayer2Sprite2.GetComponent<SpriteRenderer>().sortingOrder = 1;
        //     }
        //     if (subLayer2.transform.position == mainScene && Input.GetKeyDown(KeyCode.X))
        //     {
        //         move2 = 0.25f;
        //     }
        //     else if (Input.GetKeyDown(KeyCode.X) && (move2 == 0f))
        //     {
        //         move2 = -0.25f;
        //         subLayer2Sprite1.GetComponent<SpriteRenderer>().sortingOrder = 2;
        //         subLayer2Sprite2.GetComponent<SpriteRenderer>().sortingOrder = 2;
        //         subLayer1Sprite1.GetComponent<SpriteRenderer>().sortingOrder = 1;
        //         subLayer1Sprite2.GetComponent<SpriteRenderer>().sortingOrder = 1;
        //     }
        // }
    }
    //new Movement code using mouse clicks
    public void MoveSubroom1(){
      if(cam.orthographicSize == 35f){
        if(subLayer1.transform.position == mainScene)
        {
          move1 = -0.25f;
        }
        else
        {
          move1 = 0.25f;
          subLayer1Sprite1.GetComponent<SpriteRenderer>().sortingOrder = 2;
          subLayer1Sprite2.GetComponent<SpriteRenderer>().sortingOrder = 2;
          subLayer2Sprite1.GetComponent<SpriteRenderer>().sortingOrder = 1;
          subLayer2Sprite2.GetComponent<SpriteRenderer>().sortingOrder = 1;
      }
    }
  }
  public void MoveSubroom2(){
    if(cam.orthographicSize == 35f){
      if (subLayer2.transform.position == mainScene)
      {
          move2 = 0.25f;
      }
      else
      {
          move2 = -0.25f;
          subLayer2Sprite1.GetComponent<SpriteRenderer>().sortingOrder = 2;
          subLayer2Sprite2.GetComponent<SpriteRenderer>().sortingOrder = 2;
          subLayer1Sprite1.GetComponent<SpriteRenderer>().sortingOrder = 1;
          subLayer1Sprite2.GetComponent<SpriteRenderer>().sortingOrder = 1;
      }
    }
  }

}
