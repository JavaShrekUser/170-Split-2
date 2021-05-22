using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorFade : MonoBehaviour
{
    public GameObject[] Fragments;

    Animator anim;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
      foreach(GameObject frag in Fragments){
        if(frag.activeSelf != false){
          return;
        }
      }
      anim.SetTrigger("Active");
    }
}
