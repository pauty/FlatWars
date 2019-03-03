using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelController : MonoBehaviour
{

    public float fuelAmount = 10F;
    
	void OnTriggerEnter(Collider coll){ 
	    if(coll.gameObject.CompareTag("Player")){
	        AudioSource audiosource = gameObject.GetComponent<AudioSource>();
	        audiosource.Play();
	        Renderer rend = transform.Find("Mesh").GetComponent<MeshRenderer>();
	        rend.enabled = false;
	        coll.gameObject.GetComponent<PlayerController>().AddHealthPoints(fuelAmount);
	        Destroy(this.gameObject, audiosource.clip.length);

	    }
	}
}
