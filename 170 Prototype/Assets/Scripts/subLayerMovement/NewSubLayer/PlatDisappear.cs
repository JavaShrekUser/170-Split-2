using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlatDisappear : MonoBehaviour
{
    public GameObject Layer;

    void OnMouseOver(){
     if(Input.GetMouseButtonDown(1) && Layer.activeSelf == true){
        Layer.SetActive(false);
      }
      else if(Input.GetMouseButtonDown(1)){
        Layer.SetActive(true);
      }
    }
}
