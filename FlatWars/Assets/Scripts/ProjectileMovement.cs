using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour {
    
    
    public float speed = 70F;
    public float timeToLive = 10F;
    float spawnTime;
    Rigidbody rb;
    
	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody>();
		rb.velocity = new Vector3(0, 0, speed);
		
		Destroy(this.gameObject, timeToLive);
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnTriggerEnter(Collider coll){
	    if(coll.gameObject.tag == "Wall"){
	        Debug.Log(" yyyyyyessssss");
	        Destroy(this.gameObject);
	    }
	}
}
