using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isSubLayerMoving2 : MonoBehaviour
{
    public GameObject layer;
    float initialy;
    // Update is called once per frame
    void Start(){
      initialy = layer.transform.position.y;
    }
    void Update()
    {
      if(layer.transform.position.y != 0f && layer.transform.position.y != initialy){
        foreach (Transform t in layer.transform) {
          if(t.GetComponent<BoxCollider2D>())
            t.GetComponent<BoxCollider2D>().enabled = false;
        }
      }
      else{
        foreach (Transform t in layer.transform) {
          if(t.GetComponent<BoxCollider2D>())
            t.GetComponent<BoxCollider2D>().enabled = true;
        }
      }
    }
}
