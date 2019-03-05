using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    AudioSource audiosource;
    // Start is called before the first frame update
    void Start()
    {
        audiosource = gameObject.GetComponent<AudioSource>();
        audiosource.Play();
    }
    
    public void FadeOut(float fadeTime){
        StartCoroutine(this.FadeOutCoroutine(fadeTime));
        //StopCoroutine(this.FadeOutCoroutine(fadeTime));
    }

    private IEnumerator FadeOutCoroutine(float fadeTime) {
        float startVolume = audiosource.volume;
        float prevTime;
        float currentTime = Time.realtimeSinceStartup;
        while (audiosource.volume > 0) {
            prevTime = currentTime;
            currentTime = Time.realtimeSinceStartup;
            audiosource.volume -= startVolume*(currentTime - prevTime)/fadeTime;
            yield return null;
        }
 
        audiosource.Stop ();
        audiosource.volume = startVolume;
    }
}
