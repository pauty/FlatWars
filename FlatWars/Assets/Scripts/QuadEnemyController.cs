using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadEnemyController : MonoBehaviour {

    public GameObject explosionObject;
    public float explosionDistance = 5;
    PlayerController player;
    
	// Use this for initialization
	void Start () {
	    player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {	    
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
