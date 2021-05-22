using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCam : MonoBehaviour
{
    public Camera cam;
    public GameObject words;

    // Update is called once per frame
    void Update()
    {
      if(cam.orthographicSize != 10f){
        words.SetActive(false);
      }
      else{
        words.SetActive(true);
      }

    }
}
