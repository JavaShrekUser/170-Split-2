using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchHideLvl10 : MonoBehaviour{

public GameObject showObj1;
public GameObject showObj2;
public GameObject showObj3;
public GameObject showObj4;
public GameObject showObj5;
  public float timer = 1f;
  private float cdTimer;
  // timer to set showObj back to true when not
  // colliding with pressure plate
  private void Update() {
    if (cdTimer > 0) {
      cdTimer -= Time.deltaTime;
      if (cdTimer <= 0f) {
        showObj1.SetActive(true);
        showObj2.SetActive(true);
        showObj3.SetActive(true);
        showObj4.SetActive(true);
        showObj5.SetActive(true);
      }
    }
  }

  // when pressure plate collide with enemy or Player
  // set showObj to false
  private void OnTriggerEnter2D (Collider2D col) {
    if (col.tag == "Player" || col.tag == "Enemy" || col.tag == "Trap" || col.tag == "Metaball_liquid") {
      // Debug.Log("pressure plate working");
        showObj1.SetActive(false);
        showObj2.SetActive(false);
        showObj3.SetActive(false);
        showObj4.SetActive(false);
        showObj5.SetActive(false);
    }
  }

  // check if the collison is still hapening
  private void OnTriggerStay2D (Collider2D col) {
   if (col.tag == "Player" || col.tag == "Enemy" || col.tag == "Trap" || col.tag == "Metaball_liquid") {
     cdTimer = timer;
   }
  }

}