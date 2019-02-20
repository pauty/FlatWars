using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelScroller : MonoBehaviour {

    public float speed = 1;
    float totalDistance; 
    Vector3 traslation;
    float sectorDepth = 1F;   
    Vector3 originalPosition;
    PlayerController player;
    
	// Use this for initialization
	void Start () {
	    sectorDepth = gameObject.GetComponent<PrismaBuilder>().sectorDepth;
		originalPosition = transform.position;
		totalDistance = 0F;
		player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update(){

	    traslation = -(player.speed*Time.deltaTime);
	    if(totalDistance >= sectorDepth){
            transform.position = originalPosition;
            totalDistance = 0F;
        }
        else{
            transform.Translate(traslation);
        	totalDistance += -traslation.z;
        }
	        
	    
	}
}
