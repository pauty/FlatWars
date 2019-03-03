using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundDestroyer : MonoBehaviour {
    
    public bool limitMinX = false;
    public bool limitMaxX = false;
    public bool limitMinY = false;
    public bool limitMaxY = false;
    public bool limitMinZ = false;
    public bool limitMaxZ = false;
    private Collider boundCollider = null;
    
	// Use this for initialization
	void Start () {
	    boundCollider = GameObject.FindGameObjectWithTag("Bounds").GetComponent<Collider>();	
	}
	
	// Update is called once per frame
	void Update () {
	    if(boundCollider == null)
	        return;
		if((limitMinX && transform.position.x < boundCollider.bounds.min.x) ||
		   (limitMaxX && transform.position.x > boundCollider.bounds.max.x) ||
		   (limitMinY && transform.position.y < boundCollider.bounds.min.y) ||
		   (limitMaxY && transform.position.y > boundCollider.bounds.max.y) ||
		   (limitMinZ && transform.position.z < boundCollider.bounds.min.z) ||
		   (limitMaxZ && transform.position.z > boundCollider.bounds.max.z)){
		    Destroy(gameObject);
	    }
    }
}
