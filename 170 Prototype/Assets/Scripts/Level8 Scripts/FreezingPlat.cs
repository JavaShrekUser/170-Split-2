using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezingPlat : MonoBehaviour
{
  public GameObject disappearingGround;
  public GameObject showingGround;

  private void OnCollisionEnter2D(Collision2D col){

    // If touching the water particles, the dG will disappear and sG will show up.
    if(col.gameObject.tag == "Metaball_liquid"){
        Debug.Log("touchin plat");
        disappearingGround.SetActive(false);
        showingGround.SetActive(true);
      }else{
        Debug.Log("not touchin plat");
        showingGround.SetActive(true);
      }

    // if collide with Player open trapdoor
  }
}
