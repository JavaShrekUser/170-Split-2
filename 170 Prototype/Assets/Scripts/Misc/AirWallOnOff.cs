using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AirWallOnOff : MonoBehaviour
{
    public GameObject wall;
    public LayerMask groundLayers;
    // Update is called once per frame
    void Update()
    {
      if(Physics2D.OverlapBox(wall.transform.position, new Vector2(.425f, 3.61f), 0f, groundLayers))
      {
        wall.tag = "Untagged";
      }
      else{
        wall.tag = "Air_Wall";
      }
    }
}
