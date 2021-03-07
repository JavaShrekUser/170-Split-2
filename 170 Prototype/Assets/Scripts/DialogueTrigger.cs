using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
  public int collect_num = 0;
  public GameObject Canvas1;
  public GameObject Canvas2;
  
  public GameObject Dialogbox1;
  public GameObject Dialogbox2;
  public Rigidbody2D Player;
  public GameObject CK;
    private void Start()
    {
        Canvas1.SetActive(true);
        Dialogbox1.SetActive(true);
        Canvas2.SetActive(false);
        Dialogbox2.SetActive(false);
        Player.constraints = (RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation);
    }
    void OnTriggerEnter2D(Collider2D other){

    if (other.gameObject.layer == 9){
        collect_num += 1;
        other.gameObject.SetActive(false);
      }
    else if (other.gameObject.layer == 14)
        {
            collect_num += 3;
            other.gameObject.SetActive(false);
        }

    if (collect_num == 3){
        Canvas2.SetActive(true);
        Dialogbox2.SetActive(true);
        CK.SetActive(true);
        //collect_num = 0;
        Player.constraints = (RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation);
      }
  }

}
