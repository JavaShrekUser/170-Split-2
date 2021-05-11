using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DialogNew : MonoBehaviour
{
  public TextMeshProUGUI textDisplay;
  public string[] sentences;
  private int index;
  public float typingSpeed;
  public GameObject box;
  public GameObject cam;

  private bool next = false;
  private bool start = true;

  void Update()
  {
    if(index == 0 && box.transform.position.y == 0 && start){
      start = false;
      StartCoroutine(Type());
    }
    if(Input.anyKeyDown && next){
      NextSentence();
    }
    else if (Input.anyKeyDown){
      textDisplay.text = sentences[index];
      next = true;
    }
  }

  IEnumerator Type()
  {
    yield return new WaitForSeconds(typingSpeed);
    foreach(char letter in sentences[index].ToCharArray())
    {
      if(next)
      {
        yield break;
      }
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
      textDisplay.text = "";
      cam.GetComponent<CameraFadeOut>().Reset();
    }
  }

}
