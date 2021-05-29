using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchFadeOut : MonoBehaviour
{
    public GameObject Object;
    public SpriteRenderer rend;
    public bool startProcess = false;
    public SwitchAnimation1TimeUse switchUsed;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        switchUsed = GameObject.FindGameObjectWithTag("Switch").GetComponent<SwitchAnimation1TimeUse>();
    }

    void Update ()
    {
        if(switchUsed.buttonTouch == true && startProcess == false)
        {
            StartCoroutine("FadeOut");
            startProcess = true;
        }

        if(rend.material.color.a < 0)
        {
            Object.SetActive(false);
        }
    }

    IEnumerator FadeOut()
    {
        for(float f = 1f; f >= -0.05f; f -= 0.05f)
        {
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
        
    }

    public void startFading()
    {
        StartCoroutine("FadeOut");
    }
}
