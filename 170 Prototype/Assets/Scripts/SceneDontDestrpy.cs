using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneDontDestrpy : MonoBehaviour
{
    public AudioSource Transaction;

    private static SceneDontDestrpy instance = null;
    public static SceneDontDestrpy Instancey
    {
        get { return instance; }
    }
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        
        instance = this;
        
        DontDestroyOnLoad(this.gameObject);
    }
}
