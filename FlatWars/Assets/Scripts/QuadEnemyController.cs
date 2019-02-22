using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadEnemyController : MonoBehaviour {

    public GameObject explosionObject;
    public float explosionDistance = 5;
    PlayerController player;
    EnemyBaseBehaviour baseBehaviour;
    
	// Use this for initialization
	void Start () {
	    player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
	    baseBehaviour = gameObject.GetComponent<EnemyBaseBehaviour>();
	}
	
	// Update is called once per frame
	void Update () {
	    bool mustExplode = (baseBehaviour.lifePoints <= 0F) || 
	                       (Vector3.Distance(player.gameObject.transform.position, transform.position)  < explosionDistance);
	    if(mustExplode){
	    	Instantiate(explosionObject, transform.position, Quaternion.identity);
	        Destroy(this.gameObject);
	    }
	}

	
}
