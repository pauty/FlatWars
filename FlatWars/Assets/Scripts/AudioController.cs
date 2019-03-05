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
        StopCoroutine(this.FadeOutCoroutine(fadeTime));
    }

    private IEnumerator FadeOutCoroutine(float fadeTime) {
        float startVolume = audiosource.volume;
        Debug.Log("coroutine");
        while (audiosource.volume > 0) {
            audiosource.volume -= startVolume * Time.deltaTime/fadeTime;
 
            yield return null;
        }
 
        audiosource.Stop ();
        audiosource.volume = startVolume;
    }
}
