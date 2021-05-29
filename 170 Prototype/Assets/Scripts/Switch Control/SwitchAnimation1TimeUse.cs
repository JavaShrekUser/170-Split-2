using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchAnimation1TimeUse : MonoBehaviour
{
     //Animation movements
    public Animator animator;

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

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player" || col.tag == "Enemy" || col.tag == "Trap") 
        {
            switchSound.Play();
            buttonTouch = true;
        }

    }
    // check if the collison is still hapening
    private void OnTriggerStay2D (Collider2D col) {
        if (col.tag == "Player" || col.tag == "Enemy" || col.tag == "Trap") {
            buttonTouch = true;
        }
    }
   
}
