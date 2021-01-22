using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchActive : MonoBehaviour {
  public GameObject hidedObj;
  private float timer;

  // timer to set hidedObj back to true when not
  // colliding with pressure plate
  private void Update() {
    if (timer > 0) {
      timer -= Time.deltaTime;
      if (timer <= 0f) {
        hidedObj.SetActive(true);
      }
    }
  }

  // when pressure plate collide with enemy or Player
  // set hidedObj to false
  private void OnTriggerEnter2D (Collider2D col) {
    if (col.tag == "Player" || col.tag == "Enemy") {
      // Debug.Log("pressure plate working");
      hidedObj.SetActive(false);
    }
  }

  // check if the collison is still hapening
  private void OnTriggerStay2D (Collider2D col) {
   if (col.tag == "Player" || col.tag == "Enemy") {
     timer = 1f;
   }
  }

}
