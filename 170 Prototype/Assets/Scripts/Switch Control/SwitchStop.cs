using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchStop : MonoBehaviour
{
    public Rigidbody2D rb;
    public float timer = 1f;
    private float cdTimer;
    // timer to set showObj back to true when not
    // colliding with pressure plate
    private void Update()
    {
        if (cdTimer > 0)
        {

            cdTimer -= Time.deltaTime;
            if (cdTimer <= 0f)
            {
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
                /*rb.constraints =
                    RigidbodyConstraints2D.FreezePositionY |
                    RigidbodyConstraints2D.FreezeRotation;*/
            }
        }
    }

    // when pressure plate collide with enemy or Player
    // set showObj to false
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            // Debug.Log("pressure plate working");
            //rb.constraints = RigidbodyConstraints2D.FreezeAll;
            rb.constraints =
                    RigidbodyConstraints2D.FreezePositionY |
                    RigidbodyConstraints2D.FreezeRotation;
        }
    }

    // check if the collison is still hapening
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            cdTimer = timer;
        }
    }

}
