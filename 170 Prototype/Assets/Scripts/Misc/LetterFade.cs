using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterFade : MonoBehaviour
{
    public GameObject Fragment;

    Animator anim;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
      if(Fragment.activeSelf == false){
        anim.SetTrigger("Active2");
        return;
      }
    }
}