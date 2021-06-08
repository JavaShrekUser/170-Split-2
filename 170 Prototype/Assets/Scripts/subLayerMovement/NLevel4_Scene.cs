using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//for playtest purpose

public class NLevel4_Scene : MonoBehaviour
{

    public GameObject player;
    public Camera cam;
    public GameObject subLayer2;
    public GameObject Button2;
    public GameObject collect3;
    public GameObject door;

    public AudioSource Starting;
    public AudioSource OpenMap;
    public AudioSource CloseMap;
    public AudioSource MoveRoom;
    public AudioSource PickUp;
    public AudioSource SomethingHappen; // pick up apple sound for now
    public AudioSource ChangeScene; // open door \
    public GameObject tutorial;

    //for standing on platform alert use
    public bool colorChange = false;
    public int blinkTime = 5;
    public float blinkDuration = .25f;


    Vector3 mainScene = new Vector3(0, 0, 0);
    Vector3 subStart2;

    float move2 = 0f;
    Rigidbody2D rb;
    bool zoomOut = false;
    bool zoomIn = false;

    private int nextScene;//for playtest purpose
    private int lastScene;//for playtest purpose
    private void Start()//for playtest purpose
    {
        //Starting.Play();
        rb = player.GetComponent<Rigidbody2D>();

        subStart2 = subLayer2.transform.position;
        nextScene = SceneManager.GetActiveScene().buildIndex + 1;//for playtest purpose
        lastScene = SceneManager.GetActiveScene().buildIndex - 1;//for playtest purpose

    }
    void Update(){
      if (Input.GetButtonDown("ShowMap") && cam.orthographicSize == 10f)
      {
          if(tutorial){
            tutorial.SetActive(false);
          }
          OpenMap.Play();
          rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
          zoomOut = true;
      }
      else if (cam.orthographicSize == 35f && Input.GetButtonDown("ShowMap"))
      {
          CloseMap.Play();
          rb.constraints = RigidbodyConstraints2D.None;
          rb.constraints = RigidbodyConstraints2D.FreezeRotation;
          zoomIn = true;
      }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.K))//for playtest purpose
        {
            SceneManager.LoadScene(nextScene);//for playtest purpose
        }
        else if (Input.GetKeyDown(KeyCode.J))//for playtest purpose
        {
            SceneManager.LoadScene(lastScene);//for playtest purpose
        }
        if (zoomOut)
        {
            if (cam.orthographicSize == 35f)
            {
                Button2.SetActive(true);
                zoomOut = false;
            }
            else
            {
                cam.orthographicSize += 1f;
            }
        }
        else if (zoomIn)
        {
            if (cam.orthographicSize == 10f)
            {
                zoomIn = false;
            }
            else
            {
                Button2.SetActive(false);
                cam.orthographicSize -= 1f;
            }
        }

        if (move2 != 0f)
        {
            subLayer2.transform.Translate(0, move2, 0);
            if (subLayer2.transform.position == mainScene || subLayer2.transform.position == subStart2)
            {
                move2 = 0f;
                MoveRoom.Stop();
            }
        }

        if (!collect3.activeSelf)
        {
            door.SetActive(true);
        }


    }
    //New button click movment

    public void MoveSubroom2()
    {
        if (cam.orthographicSize == 35f)
        {
            if (IsGrounded(subLayer2))
            {
                //if standing on and try clicking, reset the blink timer
                blinkTime = 5;
                blinkDuration = .25f;
                colorChange = true;
            }
            else if (subLayer2.transform.position == mainScene)
            {
                MoveRoom.Play();
                move2 = 0.75f;
                colorChange = false;
            }
            else if (subLayer2.transform.position == subStart2)
            {
                MoveRoom.Play();
                move2 = -0.75f;
                colorChange = false;
            }

        }
    }
    public bool IsGrounded(GameObject subLayer)
    {
        Collider2D playerCol = player.GetComponent<Collider2D>();
        foreach (Transform t in subLayer.transform)
        {
            if (t.GetComponent<EdgeCollider2D>())
            {
                if (Physics2D.IsTouching(t.GetComponent<EdgeCollider2D>(), playerCol))
                {
                    return true;
                }
            }
        }
        return false;
    }

}
