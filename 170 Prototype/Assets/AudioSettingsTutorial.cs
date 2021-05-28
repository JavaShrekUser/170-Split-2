
using UnityEngine;

public class AudioSettingsTutorial : MonoBehaviour
{

    public static readonly string BackgroundPref = "BackgroundPref";
    public static readonly string SoundEffectsPref = "SoundEffectsPref";
    private float backgroundFloat, soundEffectsFloat;
    public AudioSource bgm;
    public AudioSource[] sfx;
    void Awake()
    {
        ContinueSettings();
    }
    private void ContinueSettings()
    {
        backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref);
        soundEffectsFloat = PlayerPrefs.GetFloat(SoundEffectsPref);

        bgm.volume = backgroundFloat;

        for (int i = 0; i < sfx.Length; i++)
        {
            sfx[i].volume = soundEffectsFloat;
        }
    }
}
