using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchSwitch : MonoBehaviour
{
  public GameObject showObj1;
  public GameObject showObj2;
  public bool switchCheck = false;
  public float timer = 1f;
  private float cdTimer;
  // timer to set showObj back to true when not
  // colliding with pressure plate
  private void Update() {
    if(switchCheck == true)
    {
        showObj1.SetActive(false);
        showObj2.SetActive(true);
    }
    else{
        showObj1.SetActive(true);
        showObj2.SetActive(false);
    }
  }

  // when pressure plate collide with enemy or Player
  // set showObj to false
  private void OnTriggerEnter2D (Collider2D col) {
    if (col.tag == "Player" || col.tag == "Enemy" || col.tag == "Trap") {
      // Debug.Log("pressure plate working");
      switchCheck = !switchCheck;

    }
  }

}