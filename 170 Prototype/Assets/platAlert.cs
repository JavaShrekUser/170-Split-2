using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platAlert : MonoBehaviour
{

    public SubLayerMove subMove;
    public GameObject subRoomSet;
    // public test CheckGround;
    public bool touch = false;

    public Color initColor = Color.white;
    public Color alertColor = Color.white;
    SpriteRenderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        subMove = GameObject.FindGameObjectWithTag("Player").GetComponent<SubLayerMove>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //touch = GameObject.FindGameObjectWithTag("Player").GetComponent<SubLayerMove>().changeColor;
        touch = subMove.IsGrounded(subRoomSet);
        Debug.Log(touch);

        if(touch == true)
        {
            rend.material.color = alertColor;
        }
        else
        {
            rend.material.color = initColor;
        }

        // for(int i = 3; i > 0; i--)
        // {
        //     for(float j = 1f; j > 0; j -= 0.1f)
        //     {
        //         rend.material.color = initColor;
        //     }
        //     for(float k = 1f; k > 0; k -= 0.1f)
        //     {
        //         rend.material.color = alertColor;
        //     }
        // }
    }

    // private void OnCollisionEnter2D(Collision2D col) {

    //     if(col.gameObject.tag == "Player" && touch == true)
    //     {
    //         rend.material.color = alertColor;
    //     }

    // }

    // private void OnCollisionExit(Collision col) {

    //     rend.material.color = initColor;
        
    // }
}
