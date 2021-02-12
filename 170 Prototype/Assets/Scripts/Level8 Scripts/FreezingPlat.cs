using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezingPlat : MonoBehaviour
{
  public GameObject disappearingGround;
  public GameObject showingGround;

  private void OnTriggerEnter2D(Collider2D col){

    // If touching the water particles, the dG will disappear and sG will show up.
    if(col.gameObject.layer == 4){
        Debug.Log("touchin plat");
        disappearingGround.SetActive(false);
        showingGround.SetActive(true);
      }

    // if collide with Player open trapdoor
  }
}
