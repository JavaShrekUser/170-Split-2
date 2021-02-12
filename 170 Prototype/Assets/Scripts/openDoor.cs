using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openDoor : MonoBehaviour
{
  public GameObject trapDoor;
  public GameObject icePlat1;
  public int touched_water = 0;

  private void OnTriggerEnter2D(Collider2D col){

    if(col.gameObject.layer == 4){
        touched_water += 1;
      }

    if(touched_water == 15){
        GetComponent<Renderer>().material.color = Color.blue;
        trapDoor.SetActive(false);
      }

    // if collide with Player open trapdoor
  }
}
