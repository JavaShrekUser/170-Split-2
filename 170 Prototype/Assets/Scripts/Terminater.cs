using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminater : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(GameObject.Find("Starting"));
    }

}
