using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class difusseTrap : MonoBehaviour
{
    private int touched_water = 0;
    public GameObject subroom;
    public AudioSource Boiling;

    void OnTriggerEnter2D(Collider2D col){
      if(col.gameObject.layer == 4 && subroom.transform.position.y == 0){
        Boiling.Play();
        touched_water += 1;
      }
      if(touched_water == 10){
        Collider2D selfCollider = GetComponent<Collider2D>();
        selfCollider.isTrigger = false;
        GetComponent<Renderer>().material.color = Color.blue;
      }
    }
}
