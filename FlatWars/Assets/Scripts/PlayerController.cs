using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    
    [Header("Health Settings")]
    public float maxHealthPoints;
    public float healthPoints;
    public float healthPointsDecreaseSpeed;
    public float damageOnWallHit = 10F;   
    public float invincibilityDuration = 2F;
    float invincibilityEndTime;
    bool invincible = false;
    
    [Header("Movement Settings")]
    public float minSpeed = 40F;
    public float baseSpeed = 70F;
    public float maxSpeed = 140F;
    public Vector3 speed = new Vector3(0F, 0F, 70F);
    public float rotationSpeed = 500F;
    public float movementSpeed = 16F;
    Rigidbody rb;
    Vector3 updateSpeed;
    
    [Header("Attack Settings")]
    public GameObject projectile;
    public float fireInterval = 0.05F;
    bool canShoot = true;
    float fireTime;
    Transform gun1;
    Transform gun2;
    
    [Header("Animation Settings")]
    public float flickeringInterval = .2F;
    float flickeringSwitchTime;
    Animator animator;
    Renderer rend;
    
    [Header("Audio Settings")] 
    public AudioClip shootSound;
    public AudioClip wallHitSound;    
    AudioSource audiosource;
    
	// Use this for initialization
	void Start () {
		fireTime = Time.time;
		rb = gameObject.GetComponent<Rigidbody>();
		updateSpeed = speed;
		gun1 = transform.Find("Gun1");
		gun2 = transform.Find("Gun2");
		animator = GetComponent<Animator>();
		rend = transform.Find("Mesh").GetComponent<Renderer>();
		healthPoints = Mathf.Min(healthPoints, maxHealthPoints);
		audiosource = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {	
	    if(Time.timeScale > 0F){
	        //shoot
	         bool shooting = Input.GetButton("Fire");
	         if(shooting && canShoot){
	            //FIRE	        
	            Instantiate(projectile, gun1.position, gun1.rotation);	          
	            Instantiate(projectile, gun2.position, gun2.rotation);	        
	            Debug.Log(0);
	            fireTime = Time.time;	
	            audiosource.clip = shootSound;
	            audiosource.Play();        
	         }
	         canShoot = (Time.time - fireTime >= fireInterval) || !shooting;
	         
	         //velocity
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
	         
	         //rotation
	         animator.SetFloat("RotationValue", Input.GetAxis("RButton") - Input.GetAxis("LButton"));
	         
	         //movement      
             float dx = Input.GetAxis("JoyLX");
             float dy = Input.GetAxis("JoyLY");
             Vector3 movement = new Vector3(dx, dy, 0f).normalized;
             rb.velocity = movement * movementSpeed;      
             
             healthPoints = Mathf.Max(0F, healthPoints - healthPointsDecreaseSpeed*Time.deltaTime);
             
             if(invincible){
                if(Time.time >= invincibilityEndTime){
                    rend.enabled = true;
                    invincible = false;
                }
                else if(Time.time >= flickeringSwitchTime){
                    rend.enabled = !rend.enabled;             
                    flickeringSwitchTime = Time.time + flickeringInterval;
                }
             }
       }
		
	}
	
	void LateUpdate(){
	    speed = updateSpeed;
	}
	
	public void AddHealthPoints(float amount){
	    if(healthPoints > 0F)
	        healthPoints = Mathf.Min(maxHealthPoints, healthPoints + amount);
	}
	
	public void TakeDamage(float amount){
	    if(!invincible){
	        healthPoints = Mathf.Max(0F, healthPoints - amount);
	        invincible = true;
	        invincibilityEndTime = Time.time + invincibilityDuration;
	    }
	}
	
	void OnCollisionEnter(Collision coll){
	    if(coll.gameObject.CompareTag("Wall")){
	        this.TakeDamage(this.damageOnWallHit);
	        audiosource.clip = wallHitSound;
	        audiosource.Play();
	    }
	}
	
}
