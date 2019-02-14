using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleEnemyController : MonoBehaviour {

    public float speed = 70;
    Rigidbody rb;
    
	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody>();
		
	}
	
	// Update is called once per frame
	void Update () {
	    rb.velocity = new Vector3(0, 0, speed);
	}
	
	void OnCollisionEnter(Collision coll){
	    if(coll.collider.gameObject.tag == "PlayerProjectile")
	        Debug.Log("hit");
	    if(coll.collider.gameObject.tag == "Player")
	        Debug.Log("player");
	        
	}
	
	void OnTriggerEnter(Collider coll){
	

	    if(coll.gameObject.tag == "PlayerProjectile")
	        Debug.Log("HIT");
	        
	}
	
}
