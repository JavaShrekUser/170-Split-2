using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    public void Expand(){
      transform.localScale = new Vector3(1.4f,1.4f,1f);
    }
    public void Small(){
      transform.localScale = new Vector3(1f,1f,1f);
    }
}
