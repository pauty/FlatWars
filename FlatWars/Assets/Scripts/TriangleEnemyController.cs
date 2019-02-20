using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleEnemyController : MonoBehaviour {

    
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnCollisionEnter(Collision coll){
	    if(coll.collider.gameObject.tag == "Player")
	        Debug.Log("player");
	        
	}
	
	void OnTriggerEnter(Collider coll){
	    if(coll.gameObject.tag == "PlayerProjectile")
	        Debug.Log("HIT");
	        
	}
	
}
