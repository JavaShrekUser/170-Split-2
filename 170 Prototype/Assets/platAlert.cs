using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platAlert : MonoBehaviour
{

    //get class object used for calling variables
    public SubLayerMove subMove;
    public GameObject subRoomSet;

    //boolean detection condition
    public bool touch = false;
    public bool standOn = false;

    //failed variables save for example
    // public bool changeNow = false;
    // public int blinkTimePlat;
    // public float blinkDurationPlat;

    //initial plat color and later alert changed color
    public Color initColor = Color.white;
    public Color alertColor = Color.white;
    SpriteRenderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        subMove = GameObject.FindGameObjectWithTag("Player").GetComponent<SubLayerMove>();

        //failed tried save for example
        // blinkTimePlat = subMove.blinkTime;
        // blinkDurationPlat = subMove.blinkDuration;
        // changeNow = subMove.colorChange;
        
    }

    // Update is called once per frame
    void Update()
    {
        //failed tried save for example
        //changeNow = GameObject.FindGameObjectWithTag("Player").GetComponent<SubLayerMove>().colorChange;
        // blinkTimePlat = GameObject.FindGameObjectWithTag("Player").GetComponent<SubLayerMove>().blinkTime;
        // blinkDurationPlat = GameObject.FindGameObjectWithTag("Player").GetComponent<SubLayerMove>().blinkDuration;
        
        //touch sub platform condition
        touch = subMove.IsGrounded(subRoomSet);

        //run every frame so it response upon condition met
        AlertChange();
            
    }

    //check for condition upon enter and exit
    private void OnCollisionEnter2D(Collision2D col) {

        if(col.gameObject.tag == "Player")
        {
            standOn = true;
        }

    }

    private void OnCollisionExit2D(Collision2D col) {

            standOn = false;
        
    }

    //check condition and excecute once meet requirement
    public void AlertChange()
    {
        
        if(touch == true && standOn == true && subMove.colorChange == true)
        {
            //blink x amount of time
            if(subMove.blinkTime > 0)
            {
                //change color based on even or odd number
                if(subMove.blinkTime % 2 != 0)
                {
                    rend.material.color = initColor;
                }
                else
                {
                    rend.material.color = alertColor;
                }
                //alert color change duration
                if(subMove.blinkDuration > 0)
                {
                    subMove.blinkDuration -= Time.deltaTime;
                    //once finished reset the timer and decrease 1 change time
                    if(subMove.blinkDuration <= 0)
                    {
                        subMove.blinkDuration = .25f;
                        subMove.blinkTime--;
                    }
                    
                }
                
            }

        }
        else //change the color back to normal incase color difference
        {
            rend.material.color = initColor;
        }
        
    }

}
