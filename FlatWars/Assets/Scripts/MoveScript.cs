using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour {


    public float speed = 1;
    float traslation;
    float sectorDepth = 1F;   
    Vector3 originalPosition;
    
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update(){
	    traslation = speed*Time.deltaTime;
        transform.Translate(0, 0 , -traslation);	        
	    
	}
}
