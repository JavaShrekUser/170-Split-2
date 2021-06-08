using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragmentHover : MonoBehaviour
{
    // Update is called once per frame
    void FixedUpdate()
    {
      transform.Translate( new Vector3(0f,0.00625f,0f) * Mathf.Cos(Time.time));
    }
}
