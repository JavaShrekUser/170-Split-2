using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InjuredKeep : MonoBehaviour
{
    public AudioSource Transaction;

    private static InjuredKeep instance = null;
    public static InjuredKeep Instancey
    {
        get { return instance; }
    }
    void Awake()
    {
        instance = this;

        DontDestroyOnLoad(this.gameObject);
    }
}
