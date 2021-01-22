using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchAppear : MonoBehaviour {
  public GameObject hidedObj;
  private float timer;

  // timer to set hidedObj back to false when not
  // colliding with pressure plate
  private void Update() {
    if (timer <= 0f) {
      hidedObj.SetActive(false);
    }
    if (timer > 0) {
      timer -= Time.deltaTime;
    }
  }

  // when pressure plate collide with enemy or Player
  // set hidedObj to true
  private void OnTriggerEnter2D (Collider2D col) {
    if (col.tag == "Player" || col.tag == "Enemy") {
      //Debug.Log("pressure plate working");
      timer = 1f;
      hidedObj.SetActive(true);
    }
  }

  // check if the collison is still hapening
  private void OnTriggerStay2D (Collider2D col) {
    if (col.tag == "Player" || col.tag == "Enemy") {
      timer = 1f;
    }
  }

}
