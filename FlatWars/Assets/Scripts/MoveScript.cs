using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour {

    Vector3 traslation; 
    PlayerController player;
    
	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update(){
	    traslation = -(player.speed*Time.deltaTime);
        transform.Translate(traslation, Space.World);	        	    
	}
}
