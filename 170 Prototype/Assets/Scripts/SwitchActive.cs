using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchActive : MonoBehaviour {
  public GameObject hidedObj;
  private float timer;

  private void Update() {
    if (timer > 0) {
      timer -= Time.deltaTime;
      if (timer <= 0f) {
        hidedObj.SetActive(true);
      }
    }
  }

  private void OnTriggerEnter2D (Collider2D col) {
    if (col.tag == "Player" || col.tag == "Enemy") {
      Debug.Log("button working");
      hidedObj.SetActive(false);
    }
  }

  private void OnTriggerStay2D (Collider2D col) {
   if (col.tag == "Player" || col.tag == "Enemy") {
     timer = 1f;
   }
  }

}
