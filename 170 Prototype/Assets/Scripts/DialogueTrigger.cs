using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
  public int collect_num = 0;
  public GameObject Canvas;
  public GameObject Dialogbox;
  public Rigidbody2D Player;
  void OnTriggerEnter2D(Collider2D other){

    if (other.gameObject.layer == 9){
        collect_num += 1;
        Destroy (other.gameObject);
      }
    if (collect_num == 3){
        Canvas.SetActive(true);
        Dialogbox.SetActive(true);
        Player.constraints = RigidbodyConstraints2D.FreezePosition;
      }
  }

}
