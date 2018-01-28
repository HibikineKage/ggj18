using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fadepanel : MonoBehaviour {
    Image image;

    float time;
    bool runninng;
    void Start () {
        image = GetComponent<Image>();
	}
	
	 public void FadeOut(float  fadeTime,System.Action fadeEnd)
    {
        if (runninng)
        {
            Debug.LogWarning(gameObject.name + "が実行中です");
            return;
        }
        StartCoroutine(Fade(fadeTime,fadeEnd));
    }

    IEnumerator Fade(float fadeTime, System.Action fadeEnd)
    {
        runninng = true;
        do
        {
            time += Time.deltaTime;
            image.color = new Color(0, 0, 0, time/fadeTime);
            yield return null;
        } while (time / fadeTime <=1);
        fadeEnd();
        runninng = false;
    }
}
