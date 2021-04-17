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
        changeNow = GameObject.FindGameObjectWithTag("Player").GetComponent<SubLayerMove>().colorChange;
        touch = subMove.IsGrounded(subRoomSet);

        AlertChange();
            
        
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
                        blinkDuration = .25f;
                        blinkTime--;
                    }
                    
                }
                
            }

        }
        else
        {
            
            if(blinkTime != 5 || blinkDuration != .25f)
            {
                blinkTime = 5;
                blinkDuration = .25f;
                changeNow = false;
            }
            rend.material.color = initColor;
        }
        
    }

}
