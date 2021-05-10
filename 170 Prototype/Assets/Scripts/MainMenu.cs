using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  public AudioSource MenuBgm;

  public void Start()//for playtest purpose
  {
    MenuBgm.Play();
  }
  public void PlayGame()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
  }
  public void QuitGame()
  {
    Application.Quit();
  }
}
