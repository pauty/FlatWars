using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour {


    public float speed = 1;
    float traslation;
    float sectorDepth = 1F;   
    Vector3 originalPosition;
    PlayerController player;
    
	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update(){
	    traslation = player.speed*Time.deltaTime;
        transform.Translate(0, 0 , -traslation);	        
	    
	}
}
