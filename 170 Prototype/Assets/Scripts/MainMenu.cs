using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{


    //[Range(0, 1)]
    //public float volume_slider = 0.5f;

    public void Start()//for playtest purpose
  {

    }

    public void Update()
    {
        //MenuBgm.volume = volume_slider;
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
