using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {
    
    public float xRotation = 0F;
    public float yRotation = 0F;
    public float zRotation = 0F;
    public bool relativeToWorld = false;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    if(!relativeToWorld)
		    transform.Rotate(xRotation, yRotation, zRotation, Space.Self);
		else
		    transform.Rotate(xRotation, yRotation, zRotation, Space.World);
	}
}
