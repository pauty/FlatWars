using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadEnemyController : MonoBehaviour {

    public GameObject explosionObject;
    public float explosionDistance = 5;
    PlayerController player;
    EnemyBaseBehaviour baseBehaviour;
    GameController gameController;
    
	// Use this for initialization
	void Start () {
	    player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
	    baseBehaviour = gameObject.GetComponent<EnemyBaseBehaviour>();
	    gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update () {
	    bool mustExplode = (baseBehaviour.healthPoints <= 0F) || 
	                       (Vector3.Distance(player.gameObject.transform.position, transform.position)  < explosionDistance);
	    if(mustExplode){
	    	Instantiate(explosionObject, transform.position, Quaternion.identity);
	        Destroy(this.gameObject);
	        if(gameController.spawnFuel()){
	            Instantiate(baseBehaviour.fuelObject, transform.position, transform.rotation);
	        }
	    }
	}

	
}
