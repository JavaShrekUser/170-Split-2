using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragmentHover : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
      transform.Translate( new Vector3(0f,0.0005f,0f) * Mathf.Cos(Time.time));
    }
}
