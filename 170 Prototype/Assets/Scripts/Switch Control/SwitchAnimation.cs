using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchAnimation : MonoBehaviour
{

    //Animation movements
    public Animator animator;

    public float timer = .1f;
    private float cdTimer;
    private bool buttonTouch = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cdTimer > 0) 
        {
            cdTimer -= .1f;
            if (cdTimer <= 0f) {
                buttonTouch = false;
            }
        }

        animator.SetBool("Touching", buttonTouch);

    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Player" || col.tag == "Enemy" || col.tag == "Trap") 
        {
            buttonTouch = true;
            cdTimer = timer;
        }

    }
}
