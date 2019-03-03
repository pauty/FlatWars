using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereExplosionController : MonoBehaviour
{

    public float maxRadius = 7F;
    public float explosionSpeed = 3F;
    public float damage = 10F;
    public float destroyDelay = 1F;
    float currentScale;
    bool stop = false;
    AudioSource audiosource;
    
    // Start is called before the first frame update
    void Start()
    {
        currentScale = 1F;
        //audiosource = gameObject.GetComponent<AudioSource>();
        //audiosource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(!stop){
            currentScale += explosionSpeed*Time.deltaTime;
            transform.localScale = new Vector3 (currentScale, currentScale, currentScale);
            if(currentScale >= maxRadius){
                stop = true;
                Destroy(this.gameObject, destroyDelay);
            }
        }
    }
    
    void OnTriggerEnter(Collider coll){
        if(coll.gameObject.CompareTag("Player")){
            coll.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
        }
    }
}
