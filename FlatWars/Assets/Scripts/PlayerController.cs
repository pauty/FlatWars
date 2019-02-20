using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    public float minSpeed = 40F;
    public float baseSpeed = 70F;
    public float maxSpeed = 140F;
    /*
    bool axisFreeX = true;
    bool axisFreeY = true;
    float nextTime;
    float timeInterval = 0.1F;
    bool go = true;
    */
    Rigidbody rb;
    Vector3 knockback;
    public float speed = 70F;
    float updateSpeed;
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
	     
	     
	     if((Input.GetButton("SpeedUp") && speed < maxSpeed))
	        updateSpeed += 1;
	     else if((Input.GetButton("SpeedDown") && speed > minSpeed))
	        updateSpeed -= 1;
	     else{
	        if(speed < baseSpeed)
	            updateSpeed += 1;
	        else if(speed > baseSpeed)
	            updateSpeed -= 1;
	     }

	     
	     
	     
	     /*   
	     int xAxis = (int)Input.GetAxisRaw("DpadX");
         if(xAxis != 0 && axisFreeX){
            axisFreeX = false;
            if(xAxis == -1)
                transform.Translate(-5,0,0);
            else 
                transform.Translate(5,0,0);
         }
         else if(xAxis == 0)   
            axisFreeX = true;
            
         int yAxis = (int)Input.GetAxisRaw("DpadY");
         if(yAxis != 0 && axisFreeY){
            axisFreeY = false;
            if(yAxis == -1)
                transform.Translate(0,5,0);
            else 
                transform.Translate(0,-5,0);
         }
         else if(yAxis == 0)   
            axisFreeY = true;
         */
         
         /*
         if(Time.time >= nextTime || go){
            nextTime = Time.time + timeInterval;
            if(Input.GetAxisRaw("DpadX") == -1){
                //transform.Translate(-3,0,0);
                rb.MovePosition(new Vector3(transform.position.x - 3, transform.position.y ,transform.position.z));
            }
            else if(Input.GetAxisRaw("DpadX") == 1){
                //transform.Translate(3,0,0);
                 rb.MovePosition(new Vector3(transform.position.x +3, transform.position.y ,transform.position.z));
            }
            
            if(Input.GetAxisRaw("DpadY") == -1){
                //transform.Translate(0,3,0);
                rb.MovePosition(new Vector3(transform.position.x, transform.position.y +3,transform.position.z));
            }
            else if(Input.GetAxisRaw("DpadY") == 1){
                //transform.Translate(0,-3,0);
                 rb.MovePosition(new Vector3(transform.position.x, transform.position.y -3,transform.position.z));
            }
         }
         go = Input.GetAxisRaw("DpadX") == 0 && Input.GetAxisRaw("DpadY") == 0;
          */
         
         float dx = Input.GetAxis("JoyLX");
         float dy = Input.GetAxis("JoyLY");
         Vector3 movement = new Vector3(dx, -dy, 0f).normalized;
         rb.velocity = movement * 16 + knockback; 
         knockback = new Vector3(0,0,0);
         //rb.AddForce(new Vector3(0,dy*4,0));           
		
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
