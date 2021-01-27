using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    Vector3 mainScene = new Vector3(0, 0, 0);
    Vector3 subStart1;
    Vector3 subStart2;

    float move1 = 0f;
    float move2 = 0f;

    private void Start()
    {
      subStart1 = subLayer1.transform.position;
      subStart2 = subLayer2.transform.position;
    }

    // Update is called once per frame
    private void Update()
    {


        if (Input.GetButtonDown("ShowMap") && cam.orthographicSize == 10f)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            cam.orthographicSize = 35f;
            
        }
        else if (move1 != 0f)
        {
            subLayer1.transform.Translate(0, move1 / 2f, 0);
            if (subLayer1.transform.position == mainScene || subLayer1.transform.position == subStart1)
            {
                move1 = 0f;
            }
        }
        else if (move2 != 0f)
        {
            subLayer2.transform.Translate(0, move2 / 2f, 0);
            if (subLayer2.transform.position == mainScene || subLayer2.transform.position == subStart2)
            {
                move2 = 0f;
            }
        }
        else if (subLayer1.transform.position == mainScene && subLayer2.transform.position == mainScene
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
        else if (cam.orthographicSize == 35f && Input.GetButtonDown("ShowMap"))
        {
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            cam.orthographicSize = 10f;
            
        }
        else if (cam.orthographicSize == 35f)
        {
            if (subLayer1.transform.position == mainScene && Input.GetKeyDown(KeyCode.C))
            {
                move1 = -0.25f;
            }
            else if (Input.GetKeyDown(KeyCode.C) && (move1 == 0f))
            {
                move1 = 0.25f;
                subLayer1Sprite1.GetComponent<SpriteRenderer>().sortingOrder = 2;
                subLayer1Sprite2.GetComponent<SpriteRenderer>().sortingOrder = 2;
                subLayer2Sprite1.GetComponent<SpriteRenderer>().sortingOrder = 1;
                subLayer2Sprite2.GetComponent<SpriteRenderer>().sortingOrder = 1;
            }
            if (subLayer2.transform.position == mainScene && Input.GetKeyDown(KeyCode.X))
            {
                move2 = 0.25f;
            }
            else if (Input.GetKeyDown(KeyCode.X) && (move2 == 0f))
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
