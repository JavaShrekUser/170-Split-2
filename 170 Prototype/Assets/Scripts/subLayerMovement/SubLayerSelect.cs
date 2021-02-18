using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubLayerSelect : MonoBehaviour
{
    public GameObject layer;
    public Camera cam;
    // Update is called once per frame
    void Update()
    {
      if(cam.orthographicSize == 10)
      {
        layer.SetActive(false);
      }
    }
}
