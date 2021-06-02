using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//for playtest purpose

public class SubLayerMove8 : MonoBehaviour
{
    public Rigidbody2D rb;
    public Camera mainCam;
    public Camera effectCam;
    public GameObject subLayer1;
    public GameObject subLayer2;

    public GameObject ButtonCanvas;

    public GameObject Manual;

    Vector3 mainScene = new Vector3(0, 0, 0);
    Vector3 subStart1;
    Vector3 subStart2;

    float move1 = 0f;
    float move2 = 0f;

    private int nextScene;//for playtest purpose
    private int lastScene;//for playtest purpose

    private bool onIce = false; //check if player is on Ice for movement purposes

    private void Start()//for playtest purpose
    {
        subStart1 = subLayer1.transform.position;
        subStart2 = subLayer2.transform.position;
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

        if (Input.GetKeyDown(KeyCode.M) && mainCam.orthographicSize == 10f)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            mainCam.orthographicSize = 35f;
            effectCam.orthographicSize = 35f;
            ButtonCanvas.SetActive(true);

        }
        else if (mainCam.orthographicSize == 35f && Input.GetKeyDown(KeyCode.M))
        {
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            mainCam.orthographicSize = 10f;
            effectCam.orthographicSize = 10f;
            ButtonCanvas.SetActive(false);
        }
        if (move1 != 0f)
        {
            subLayer1.transform.Translate(0, move1 / 2f, 0);
            if (subLayer1.transform.position.y == mainScene.y || subLayer1.transform.position == subStart1)
            {
                move1 = 0f;
            }
        }
        if (move2 != 0f)
        {
            subLayer2.transform.Translate(0, move2 / 2f, 0);
            if (subLayer2.transform.position.y == mainScene.y || subLayer2.transform.position == subStart2)
            {
                move2 = 0f;
            }
        }

        else if(mainCam.orthographicSize == 35f){
            if(subLayer1.transform.position.y == mainScene.y && Input.GetKeyDown(KeyCode.C)){
               move1 = 0.25f;
             }
             else if(Input.GetKeyDown(KeyCode.C)){
               move1 = -0.25f;
             }
             if(subLayer2.transform.position.y == mainScene.y && Input.GetKeyDown(KeyCode.X)){
               move2 = -0.25f;
             }
             else if(Input.GetKeyDown(KeyCode.X)){
               move2 = 0.25f;
             }

        }

    }
    public void MoveSubroom1()
    {
        if (mainCam.orthographicSize == 35f)
        {
            if (subLayer1.transform.position == mainScene)
            {
                move1 = -0.25f;
            }
            else
            {
                move1 = 0.25f;
            }
        }
    }
    public void MoveSubroom2()
    {
        if (mainCam.orthographicSize == 35f)
        {
            if (subLayer2.transform.position == mainScene)
            {
                move2 = 0.25f;
            }
            else
            {
                move2 = -0.25f;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {

        // If collide turn onIce boolean to true
        if (col.gameObject.tag == "Ice")
        {
            onIce = true;
        }
        else
        {
            onIce = false;
        }

    }
}
