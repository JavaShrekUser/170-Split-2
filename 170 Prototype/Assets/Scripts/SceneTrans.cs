using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrans : MonoBehaviour{
    public Animator transitionAnim;
    public string sceneName;
    private bool touchingDoor;

    void Update(){
        if(touchingDoor&&Input.GetKeyDown(KeyCode.Space)){
            StartCoroutine(LoadScene());
        }
    }

    IEnumerator LoadScene(){
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName);
    }

    private void OnTriggerEnter2D(Collider2D collison){
        if(collison.tag == "Player") { 
            touchingDoor = true;
        }
    }
}
