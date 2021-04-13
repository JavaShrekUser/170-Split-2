using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchAnimation : MonoBehaviour
{

    //Animation movements
    public Animator animator;

    public float timer = 1f;
    public float cdTimer = 0f;
    public bool buttonTouch = false;

    public AudioSource switchSound;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        animator.SetBool("Touching", buttonTouch);

        if (cdTimer > 0) 
        {
            cdTimer -= 0.1f;
            if (cdTimer <= 0f) {
                buttonTouch = false;
            }
        }

    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Player" || col.tag == "Enemy" || col.tag == "Trap") 
        {
            switchSound.Play();
            buttonTouch = true;
            cdTimer = timer;
        }

    }
}
