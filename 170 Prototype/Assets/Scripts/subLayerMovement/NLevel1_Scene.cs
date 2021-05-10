using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//for playtest purpose

public class NLevel1_Scene : MonoBehaviour
{
    public GameObject player;
    public Camera cam;
    public GameObject collect3;
    public GameObject door;

    public AudioSource Starting;
    public AudioClip Loop;
    public AudioSource OpenMap;
    public AudioSource CloseMap;
    public AudioSource MoveRoom;
    public AudioSource PickUp;
    public AudioSource SomethingHappen; // pick up apple sound for now
    public AudioSource ChangeScene; // open door \

    

    //for standing on platform alert use
    public bool colorChange = false;
    public int blinkTime = 5;
    public float blinkDuration = .25f;


    Vector3 mainScene = new Vector3(0, 0, 0);

    Rigidbody2D rb;
    bool zoomOut = false;
    bool zoomIn = false;

    private int nextScene;//for playtest purpose
    private int lastScene;//for playtest purpose
    private void Start()//for playtest purpose
    {
        Starting.Play();
        rb = player.GetComponent<Rigidbody2D>();

        nextScene = SceneManager.GetActiveScene().buildIndex + 1;//for playtest purpose
        lastScene = SceneManager.GetActiveScene().buildIndex - 1;//for playtest purpose

    }

    // Update is called once per frame
    private void Update()
    {
        if (!Starting.isPlaying)
        {
            Starting.clip = Loop;
            Starting.loop = true;
            Starting.Play();
        }

        if (Input.GetKeyDown(KeyCode.E))//for playtest purpose
        {
            SceneManager.LoadScene(nextScene);//for playtest purpose
        }
        else if (Input.GetKeyDown(KeyCode.Q))//for playtest purpose
        {
            SceneManager.LoadScene(lastScene);//for playtest purpose
        }
        if (zoomOut)
        {
            if (cam.orthographicSize == 35f)
            {

                zoomOut = false;
            }
            else
            {
                cam.orthographicSize += 0.5f;
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

                cam.orthographicSize -= 0.5f;
            }
        }

        if (!collect3.activeSelf)
        {
            door.SetActive(true);
        }
        

    }
    //New button click movment
    
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
