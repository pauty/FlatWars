using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelExplosionController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ParticleSystem parts = gameObject.GetComponent<ParticleSystem>();
        float totalDuration = parts.duration + parts.startLifetime;
        Destroy(this.gameObject, totalDuration);        
    }

}
