using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    
    [Header("Health Settings")]
    public float maxHealthPoints;
    public float healthPoints;
    public float healthPointsDecreaseSpeed;
    
    [Header("Movement Settings")]
    public float minSpeed = 40F;
    public float baseSpeed = 70F;
    public float maxSpeed = 140F;
    public Vector3 speed = new Vector3(0F, 0F, 70F);
    public float rotationSpeed = 500F;
    Rigidbody rb;
    Vector3 updateSpeed;
    
    [Header("Attack Settings")]
    public GameObject projectile;
    public float fireInterval = 0.2F;
    bool canShoot = true;
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
		healthPoints = Mathf.Min(healthPoints, maxHealthPoints);
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
         Vector3 movement = new Vector3(dx, dy, 0f).normalized;
         rb.velocity = movement * 16;      
         
         healthPoints = Mathf.Max(0F, healthPoints - healthPointsDecreaseSpeed*Time.deltaTime);
		
	}
	
	void LateUpdate(){
	    speed = updateSpeed;
	}
	
	public void AddHealthPoints(float amount){
	    if(healthPoints > 0F)
	        healthPoints = Mathf.Min(maxHealthPoints, healthPoints + amount);
	}
	
}
