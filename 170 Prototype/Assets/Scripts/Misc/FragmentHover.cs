using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragmentHover : MonoBehaviour
{
    float startingY;
    bool move;
    void Start(){
      startingY = transform.position.y;
    }
    // Update is called once per frame
    void Update()
    {
      if(transform.position.y - startingY >= 0.60f){
        move = true;
      }
      else if(transform.position.y <= startingY){
        move = false;
      }
      if(move){
        transform.Translate(new Vector3(0f,-0.0005f,0f));
      }
      else{
        transform.Translate(new Vector3(0f,0.0005f,0f));
      }
    }
}
