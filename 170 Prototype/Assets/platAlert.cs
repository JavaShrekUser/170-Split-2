using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platAlert : MonoBehaviour
{

    public SubLayerMove subMove;
    public GameObject subRoomSet;
    public bool touch = false;
    public bool standOn = false;
    public bool changeNow = false;

    public int blinkTimePlat;
    public float blinkDurationPlat;

    public Color initColor = Color.white;
    public Color alertColor = Color.white;
    SpriteRenderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        subMove = GameObject.FindGameObjectWithTag("Player").GetComponent<SubLayerMove>();
        blinkTimePlat = GameObject.FindGameObjectWithTag("Player").GetComponent<SubLayerMove>().blinkTime;
        blinkDurationPlat = GameObject.FindGameObjectWithTag("Player").GetComponent<SubLayerMove>().blinkDuration;
        
    }

    // Update is called once per frame
    void Update()
    {
        changeNow = GameObject.FindGameObjectWithTag("Player").GetComponent<SubLayerMove>().colorChange;
        // blinkTimePlat = GameObject.FindGameObjectWithTag("Player").GetComponent<SubLayerMove>().blinkTime;
        // blinkDurationPlat = GameObject.FindGameObjectWithTag("Player").GetComponent<SubLayerMove>().blinkDuration;
        
        touch = subMove.IsGrounded(subRoomSet);

        AlertChange();

        changeNow = false;
            
        
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
        
        if(touch == true && standOn == true && changeNow == true)
        {

            if(blinkTimePlat > 0)
            {
                if(blinkTimePlat % 2 != 0)
                {
                    rend.material.color = initColor;
                }
                else
                {
                    rend.material.color = alertColor;
                }
                if(blinkDurationPlat > 0)
                {
                    blinkDurationPlat -= Time.deltaTime;
                    if(blinkDurationPlat <= 0)
                    {
                        blinkDurationPlat = .25f;
                        blinkTimePlat--;
                    }
                    
                }
                
            }

        }
        else
        {
            
            if(blinkTimePlat != 5 || blinkDurationPlat != .25f)
            {
                blinkTimePlat = 5;
                blinkDurationPlat = .25f;
                changeNow = false;
            }
            rend.material.color = initColor;
        }
        
    }

}
