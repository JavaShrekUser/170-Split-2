using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatHide : MonoBehaviour {

  public GameObject plat;
  public float hideTimer = 1f;
  public float showTimer = 2f;


  void OnCollisionEnter2D (Collision2D col) {
    if (col.gameObject.name.Equals("Player")) {
      Invoke ("HidePlatform", hideTimer);
    }
  }

  void OnCollisionExit2D(Collision2D col) {
    if (col.gameObject.name.Equals("Player")) {
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
