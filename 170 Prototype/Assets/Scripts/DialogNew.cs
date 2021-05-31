using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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
  private bool end = false;

  private AsyncOperation load;

  void Start(){
    load = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    load.allowSceneActivation = false;
  }

  void Update()
  {
    if(index == 0 && box.transform.position.y == 0 && start){
      start = false;
      StartCoroutine(Type());
    }
    if(Input.anyKeyDown && next && !end){
      NextSentence();
    }
    else if (Input.anyKeyDown && !end){
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
  IEnumerator Wait()
  {
    yield return new WaitForSeconds(0.65f);
    load.allowSceneActivation = true;
  }

  public void NextSentence()
  {
    next = false;
    if(index == sentences.Length - 1){
      end = true;
      textDisplay.text = "";
      cam.GetComponent<CameraFadeOut>().Reset();
      StartCoroutine(Wait());
      return;
    }
    else if (index < sentences.Length - 1)
    {
      index++;
      textDisplay.text = "";
      StartCoroutine(Type());
    }
  }

}
