using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatHide : MonoBehaviour {

  public GameObject plat;
  public PlayerMovement playerMovement;
  public float hideTimer = 0.5f;
  public float showTimer = 2f;

  void OnCollisionEnter2D (Collision2D col) {
    if (playerMovement.IsGrounded() && col.gameObject.tag == "Player") {
      Invoke ("HidePlatform", hideTimer);
    }
  }

  //void OnCollisionEnter2D (Collision2D col) {
    //if (col.gameObject.tag == "Player") {
            //plat.SetActive(false);
        //}
  //}

  void OnCollisionExit2D(Collision2D col) {
    if (col.gameObject.tag == "Player") {
      Invoke ("ShowPlatform", showTimer);
    }
  }

  void HidePlatform() {
    plat.SetActive(false);
  }

  void ShowPlatform() {
    plat.SetActive(true);
  }


}
