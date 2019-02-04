using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollTunnel : MonoBehaviour {

    public float speed = 1;
    float totalDistance; 
    float traslation;
    float sectorDepth;   
    Vector3 originalPosition;
    
	// Use this for initialization
	void Start () {
	    sectorDepth = gameObject.GetComponent<BuildPrisma>().sectorDepth;
		originalPosition = transform.position;
		totalDistance = 0F;
	}
	
	// Update is called once per frame
	void Update(){

	    traslation = speed*Time.deltaTime;
	    if(totalDistance >= sectorDepth){
            transform.position = originalPosition;
            totalDistance = 0F;
        }
        else{
            transform.Translate(0, 0 , -traslation);
        	totalDistance += traslation;
        }
	        
	    
	}
}
