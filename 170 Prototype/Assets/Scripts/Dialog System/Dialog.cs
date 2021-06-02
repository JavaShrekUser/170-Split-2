using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
  public TextMeshProUGUI textDisplay;
  public string[] sentences;
  private int index;
  public float typingSpeed;

  public GameObject Dialogbox1;
  public Rigidbody2D rb;
  public GameObject Cat;

  public AudioSource Typing;
  public bool dialog = true;


  private bool next = false;
  // private bool holding = false;

  void Start()
  {
    StartCoroutine(Type());
    Typing.Play();
  }

  // private void Update()
  // {
  //     if (rb.constraints == (RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation) && next)
  //     {
  //         if(Input.GetKey("return")){
  //           for(int i = 0; i < sentences.Length; i++){
  //             NextSentence();
  //           }
  //         }
  //         else if (Input.anyKey && !holding)
  //         {
  //           NextSentence();
  //           Typing.Play();
  //           holding = true;
  //         }
  //         else if(Input.anyKey)
  //         {
  //           holding = true;
  //         }
  //         else
  //         {
  //           holding = false;
  //         }
  //     }
  // }
  public void NextButton()
  {
    if (rb.constraints == (RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation) && next)
    {
        NextSentence();
        Typing.Play();
    }
  }

  public void SkipButton()
  {
    Typing.Stop();
    if (rb.constraints == (RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation) && next)
    {
      for(int i = 0; i < sentences.Length; i++){
        NextSentence();
        Typing.Stop();
      }
    }
  }

  IEnumerator Type()
  {
    foreach(char letter in sentences[index].ToCharArray())
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
    else{
      dialog = false;
      textDisplay.text = "";
      rb.constraints = RigidbodyConstraints2D.FreezeRotation;
      Dialogbox1.SetActive(false);
      Cat.SetActive(false);
    }
  }

}
