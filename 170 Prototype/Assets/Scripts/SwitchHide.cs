using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchHide : MonoBehaviour {
  public GameObject showObj;
  private float timer;

  // timer to set showObj back to true when not
  // colliding with pressure plate
  private void Update() {
    if (timer > 0) {
      timer -= Time.deltaTime;
      if (timer <= 0f) {
        showObj.SetActive(true);
      }
    }
  }

  // when pressure plate collide with enemy or Player
  // set showObj to false
  private void OnTriggerEnter2D (Collider2D col) {
    if (col.tag == "Player" || col.tag == "Enemy") {
      // Debug.Log("pressure plate working");
      showObj.SetActive(false);
    }
  }

  // check if the collison is still hapening
  private void OnTriggerStay2D (Collider2D col) {
   if (col.tag == "Player" || col.tag == "Enemy") {
     timer = 1f;
   }
  }

}
