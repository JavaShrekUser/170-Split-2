using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platAlert : MonoBehaviour
{

    public SubLayerMove IsGrounded;
    public GameObject layer;
    // public test CheckGround;
    public bool touch = false;

    public Color initColor = Color.white;
    public Color alertColor = Color.white;
    SpriteRenderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        IsGrounded = GameObject.FindGameObjectWithTag("Player").GetComponent<SubLayerMove>();
        
    }

    // Update is called once per frame
    void Update()
    {
        touch = IsGrounded.IsGrounded(layer);
        Debug.Log(IsGrounded.IsGrounded(layer));
        if(touch == true)
        {
            rend.material.color = alertColor;
        }
        else
        {
            rend.material.color = initColor;
        }
    }

    // private void OnCollisionEnter2D(Collision2D col) {

    //     if(col.gameObject.tag == "Player")
    //     {
    //         rend.material.color = AlertColor;
    //     }

    // }
}
