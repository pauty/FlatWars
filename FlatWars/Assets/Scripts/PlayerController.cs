using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    public float minSpeed = 40F;
    public float baseSpeed = 70F;
    public float maxSpeed = 140F;
 
    Rigidbody rb;
    Vector3 knockback;
    public Vector3 speed = new Vector3(0F, 0F, 70F);
    Vector3 updateSpeed;
    public GameObject projectile;
    bool canShoot = true;
    public float fireInterval = 0.2F;
    float fireTime;
    
	// Use this for initialization
	void Start () {
		fireTime = Time.time;
		rb = gameObject.GetComponent<Rigidbody>();
		updateSpeed = speed;
	}
	
	// Update is called once per frame
	void Update () {
	
	     bool shooting = Input.GetButton("Fire");
	     if(shooting && canShoot){
	        //FIRE
	        Vector3 pos = new Vector3(transform.position.x+1, transform.position.y, transform.position.z+10);	        
	        Instantiate(projectile, pos, Quaternion.identity);	          
	        pos.x -= 2;
	        Instantiate(projectile, pos, Quaternion.identity);	        
	        Debug.Log(0);
	        fireTime = Time.time;	        
	     }
	     canShoot = (Time.time - fireTime >= fireInterval) || !shooting;
	     
	     
	     if((Input.GetButton("SpeedUp") && speed.z < maxSpeed))
	        updateSpeed.z += 1;
	     else if((Input.GetButton("SpeedDown") && speed.z > minSpeed))
	        updateSpeed.z -= 1;
	     else{
	        if(speed.z < baseSpeed)
	            updateSpeed.z += 1;
	        else if(speed.z > baseSpeed)
	            updateSpeed.z -= 1;
	     }
         
         float dx = Input.GetAxis("JoyLX");
         float dy = Input.GetAxis("JoyLY");
         Vector3 movement = new Vector3(dx, -dy, 0f).normalized;
         rb.velocity = movement * 16 + knockback; 
         knockback = new Vector3(0,0,0);           
		
	}
	
	void LateUpdate(){
	    speed = updateSpeed;
	}
	
	
	void OnTriggerEnter(Collider coll){
	    if(coll.gameObject.CompareTag("Explosion"))
	        Debug.Log("EXPLODED");
	}
	
    void OnCollisionStay(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            knockback = contact.normal * 40; 
        }

    }
}
