using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelExplosionController : MonoBehaviour
{

    public AudioClip explosionSound;
    
    // Start is called before the first frame update
    void Start()
    {
        ParticleSystem parts = gameObject.GetComponent<ParticleSystem>();
        float particleDuration = parts.main.duration + parts.main.startLifetime.constantMax;
        float clipDuration = 0;
        AudioSource audiosource = gameObject.GetComponent<AudioSource>();
        if(audiosource != null){
            audiosource.clip = explosionSound;
            audiosource.Play();
            clipDuration = explosionSound.length;
        } 
        Destroy(this.gameObject, Mathf.Max(clipDuration, particleDuration));   
    
    }

}
