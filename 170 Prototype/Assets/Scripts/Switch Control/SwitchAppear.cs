using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchAppear : MonoBehaviour {
  public GameObject hidedObj;
  public float timer = 1f;
  private float cdTimer;

  // timer to set hidedObj back to false when not
  // colliding with pressure plate
  private void Update() {
    if (cdTimer <= 0f) {
      hidedObj.SetActive(false);
    }
    if (cdTimer > 0) {
      cdTimer -= Time.deltaTime;
    }
  }

  // when pressure plate collide with enemy or Player
  // set hidedObj to true
  private void OnTriggerEnter2D (Collider2D col) {
    if (col.tag == "Player" || col.tag == "Enemy") {
      //Debug.Log("pressure plate working");
      cdTimer = timer;
      hidedObj.SetActive(true);
    }
  }

  // check if the collison is still hapening
  private void OnTriggerStay2D (Collider2D col) {
    if (col.tag == "Player" || col.tag == "Enemy") {
      cdTimer = timer;
    }
  }

}
