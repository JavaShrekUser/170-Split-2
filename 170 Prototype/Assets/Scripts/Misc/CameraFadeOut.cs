using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFadeOut : MonoBehaviour
{
  public AnimationCurve FadeCurve = new AnimationCurve(new Keyframe(0, 1), new Keyframe(0.6f, 0.7f, -1.8f, -1.2f), new Keyframe(1, 0));

  private float _alpha = 1;
  private Texture2D _texture;
  private bool _done = true;
  private float _time;

  public void Reset()
  {
      _done = false;
      _alpha = 0;
      _time = 0;
  }

  public void OnGUI()
  {
      if (_done) return;
      if (_texture == null) _texture = new Texture2D(1, 1);

      _texture.SetPixel(0, 0, new Color(0, 0, 0, _alpha));
      _texture.Apply();
      print(_alpha);

      _time += Time.deltaTime/1.5f;
      _alpha = 1-FadeCurve.Evaluate(_time);
      GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), _texture);

      if (_alpha >= 1){
         _done = true;
    }
  }
}
