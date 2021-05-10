using UnityEngine;
using System.Collections;

public class DontDestroy : MonoBehaviour
{
    public AudioSource Starting;
    public AudioClip Loop;

    [Range(0, 1)]
    public float volume_slider = 0.5f;

    private static DontDestroy instance = null;
    public static DontDestroy Instancey
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
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
    public void Update()
    {
        Starting.volume = volume_slider;

        if (!Starting.isPlaying)
        {
        Starting.clip = Loop;
        Starting.loop = true;
        Starting.Play();
        }
    }
}