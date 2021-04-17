using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platAlert : MonoBehaviour
{

    public SubLayerMove subMove;
    public GameObject subRoomSet;
    public bool touch = false;
    public bool standOn = false;

    public int blinkTime = 5;
    public float blinkDuration = .25f;

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

        if(touch == true && standOn == true)
        {
            rend.material.color = alertColor;
            //AlertChange();
            if(blinkTime <= 0)
            {
                blinkTime = 5;
            }
        }
        else
        {
            rend.material.color = initColor;


        }

        //Debug.Log(blinkTime);

        AlertChange();

        // if(blinkTime > 0)
        // {
        //     if(blinkTime % 2 != 0)
        //     {
        //         rend.material.color = initColor;
        //     }
        //     else
        //     {
        //         rend.material.color = alertColor;
        //     }
        //     if(blinkDuration > 0)
        //     {
        //         blinkDuration -= Time.deltaTime;
        //         if(blinkDuration <= 0)
        //         {
        //             Debug.Log("Done");
        //             blinkDuration = .25f;
        //             blinkTime--;
        //         }
                
        //     }
            
        // }
        
    }

    private void OnCollisionEnter2D(Collision2D col) {

        if(col.gameObject.tag == "Player")
        {
            standOn = true;
        }

    }

    private void OnCollisionExit2D(Collision2D col) {

            standOn = false;
        
    }

    public void AlertChange()
    {
        
        if(blinkTime > 0)
        {
            if(blinkTime % 2 != 0)
            {
                rend.material.color = initColor;
            }
            else
            {
                rend.material.color = alertColor;
            }
            if(blinkDuration > 0)
            {
                blinkDuration -= Time.deltaTime;
                if(blinkDuration <= 0)
                {
                    Debug.Log("Done");
                    blinkDuration = .25f;
                    blinkTime--;
                }
                
            }
            
        }
    }

}
