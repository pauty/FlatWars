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
    public float totalDistance;
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
    public GameObject playerExplosion;
    float flickeringSwitchTime;
    float deathAnimationEndTime = -1F;
    Animator animator;
    Renderer rend;
    
    [Header("Audio Settings")] 
    public AudioClip shootSound;
    public AudioClip damageSound;    
    public float shootVolume = 1F;
    public float damageVolume = 1F;
    AudioSource audiosource;
    
    public bool gameOverConditionReached = false;
    
    bool shooting = false;
    
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
		gameOverConditionReached = false;
		totalDistance = 0F;
	}
	
	// Update is called once per frame
	void Update () {	
	    healthPoints = Mathf.Max(0F, healthPoints - healthPointsDecreaseSpeed*Time.deltaTime);
	    
	    if(healthPoints > 0F){
            //shoot
             if(Input.GetButtonDown("Fire"))
                shooting = true;
             else if(Input.GetButtonUp("Fire"))
                shooting = false;
             if(shooting && canShoot){
                //FIRE	        
                Instantiate(projectile, gun1.position, gun1.rotation);	          
                Instantiate(projectile, gun2.position, gun2.rotation);	        
                Debug.Log(0);
                fireTime = Time.time;	
                audiosource.clip = shootSound;
                audiosource.volume = shootVolume;
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
             
                        
             if(invincible && deathAnimationEndTime < 0F){
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
         else{
            updateSpeed.z = 0F;
            if(deathAnimationEndTime < 0F){
                float particleDuration = 0.5F;
                if(playerExplosion != null){           
                    GameObject explosion = Instantiate(playerExplosion, transform.position, transform.rotation);
                    ParticleSystem parts = explosion.GetComponent<ParticleSystem>();
                    particleDuration = parts.main.duration + parts.main.startLifetime.constantMax;
                }
                deathAnimationEndTime = Time.time + particleDuration;
                transform.Find("Mesh").gameObject.SetActive(false);
                GameObject audioController = GameObject.FindWithTag("AudioController");
                if(audioController != null){
                    audioController.GetComponent<AudioController>().FadeOut(1F);
                }
            }
            else if(Time.time >= deathAnimationEndTime){
                gameOverConditionReached = true;
            }
         }		
	}
	
	void LateUpdate(){
	    speed = updateSpeed;
	    totalDistance = totalDistance + updateSpeed.z*Time.deltaTime;
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
	        audiosource.clip = damageSound;
	        audiosource.volume = damageVolume;
	        audiosource.Play();
	    }
	}
	
	void OnCollisionEnter(Collision coll){
	    if(coll.gameObject.CompareTag("Wall")){
	        this.TakeDamage(this.damageOnWallHit);
	    }
	}
	
}
