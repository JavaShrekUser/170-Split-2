using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog2 : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    public GameObject Dialogbox2;
    public Rigidbody2D rb;
    public GameObject Door;

    public GameObject collectable1;
    public GameObject collectable2;
    public GameObject collectable3;
    public GameObject collectable4;

    public GameObject CK;

    public AudioSource Typing;
    public bool dialog2 = true;
    private bool next = false;
    // private bool holding = false;

    void Start()
    {
      StartCoroutine(Type());
    }

    // private void Update()
    // {
    //     if (rb.constraints == (RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation) && next)
    //     {
    //         if (!collectable4.activeSelf && CK.activeSelf)
    //         {
    //             if (Input.anyKey && !holding)
    //             {
    //                 NextSentence();
    //                 Typing.Play();
    //                 holding = true;
    //             }
    //             else if (Input.anyKey)
    //             {
    //                 holding = true;
    //             }
    //             else
    //             {
    //                 holding = false;
    //             }
    //         }
    //     }
    // }
    public void NextButton()
    {
      if (rb.constraints == (RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation) && next)
      {
        if (!collectable4.activeSelf && CK.activeSelf)
        {
          NextSentence();
          Typing.Play();
        }
      }
    }

    public void SkipButton()
    {
      Typing.Stop();
      if (rb.constraints == (RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation) && next)
      {
        if (!collectable4.activeSelf && CK.activeSelf)
        {
          for(int i = 0; i < sentences.Length; i++){
            NextSentence();
          }
        }
      }
    }


    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        next = true;
    }

    public void NextSentence()
    {
        next = false;

            if (index < sentences.Length - 1)
            {

                index++;
                textDisplay.text = "";
                StartCoroutine(Type());
            }
            else
            {
                dialog2 = false;
                textDisplay.text = "";
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                Dialogbox2.SetActive(false);
                Door.SetActive(true);
            }

    }

}
