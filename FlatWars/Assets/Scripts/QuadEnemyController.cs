using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadEnemyController : MonoBehaviour {

    public float additionalSpeed = 10F;
    public float speedVariance = 20F;
    float speed;
    Rigidbody rb;
    PlayerController player;
    public GameObject explosionObject;
    public float explosionDistance = 5;
    
	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody>();
		player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
		speed = Random.Range(-speedVariance, speedVariance) + additionalSpeed;
	}
	
	// Update is called once per frame
	void Update () {
	    rb.velocity = new Vector3(0, 0, -(player.speed + speed));
	    
	    if(Vector3.Distance(player.gameObject.transform.position, transform.position)  < explosionDistance){
	        Destroy(this.gameObject);
	        Instantiate(explosionObject, transform.position, Quaternion.identity);
	    }
	}
	
	void OnCollisionEnter(Collision coll){
	    if(coll.collider.gameObject.tag == "Player")
	        Debug.Log("player");	        
	}
	
	void OnTriggerEnter(Collider coll){
	    if(coll.gameObject.tag == "PlayerProjectile"){
	        Destroy(this.gameObject);
	        Instantiate(explosionObject, transform.position, Quaternion.identity);
	    }
	        
	}
	
}
