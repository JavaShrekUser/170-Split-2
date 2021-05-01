using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isSubLayerMoving : MonoBehaviour
{
    public GameObject layer;
    float initialy;
    // Update is called once per frame
    void Update()
    {
      if(layer.transform.position.y != 0f){
        foreach (Transform t in layer.transform) {
          if(t.GetComponent<EdgeCollider2D>()){
            t.GetComponent<EdgeCollider2D>().enabled = false;
          }
          if(t.GetComponent<BoxCollider2D>()){
            t.GetComponent<BoxCollider2D>().enabled = false;
          }
        }
      }
      else{
        foreach (Transform t in layer.transform) {
          if(t.GetComponent<EdgeCollider2D>()){
            t.GetComponent<EdgeCollider2D>().enabled = true;
          }
          if(t.GetComponent<BoxCollider2D>()){
            t.GetComponent<BoxCollider2D>().enabled = true;
          }
        }

      }
    }
}
