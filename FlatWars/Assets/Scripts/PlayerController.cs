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
    public float rotationSpeed = 500F;
    Vector3 updateSpeed;
    public GameObject projectile;
    bool canShoot = true;
    public float fireInterval = 0.2F;
    float fireTime;
    Transform gun1;
    Transform gun2;
    Animator animator;
    
	// Use this for initialization
	void Start () {
		fireTime = Time.time;
		rb = gameObject.GetComponent<Rigidbody>();
		updateSpeed = speed;
		gun1 = transform.Find("Gun1");
		gun2 = transform.Find("Gun2");
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	     bool shooting = Input.GetButton("Fire");
	     if(shooting && canShoot){
	        //FIRE	        
	        Instantiate(projectile, gun1.position, gun1.rotation);	          
	        Instantiate(projectile, gun2.position, gun2.rotation);	        
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
	     
	     animator.SetFloat("RotationValue", Input.GetAxis("RButton") - Input.GetAxis("LButton"));
	     
         
         float dx = Input.GetAxis("JoyLX");
         float dy = Input.GetAxis("JoyLY");
         Vector3 movement = new Vector3(dx, -dy, 0f).normalized;
         rb.velocity = movement * 16;           
		
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

    }
}
