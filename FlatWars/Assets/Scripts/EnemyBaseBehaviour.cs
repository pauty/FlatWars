using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseBehaviour : MonoBehaviour
{

    [Header("Movement Settings")]
    public Vector3 baseSpeed = new Vector3(0F, 0F, 10F);
    public Vector3 additionalSpeed = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
    public Vector3 additionalSpeedMin = new Vector3(0F, 0F, -5F);
    public Vector3 additionalSpeedMax = new Vector3(0F, 0F, 5F);
    public float activationDistance = 300F;
    public bool active = false;
    Vector3 speed;
    Rigidbody rb;
    PlayerController player;
    
    [Header("Health Settings")]
    public float healthPoints = 2F;
    public bool invincible = false;
    public bool delegateDestroy = false;
    public GameObject deathExplosion = null;
    public GameObject fuelObject = null;
    
    [Header("Player Damage Settings")]
    public float damage = 5F;
    
    GameController gameController;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
		player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
		gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
		if(additionalSpeed.x == float.MaxValue){
		    additionalSpeed.x = Random.Range(additionalSpeedMin.x, additionalSpeedMax.x);
		    additionalSpeed.y = Random.Range(additionalSpeedMin.y, additionalSpeedMax.y);
		    additionalSpeed.z = Random.Range(additionalSpeedMin.x, additionalSpeedMax.z);
		}
		computeSpeed();       
    }
    
    // Update is called once per frame
    void Update()
    {
        this.Move();
        if(!delegateDestroy)
            this.defaultDestroyCheck();
    }
    
    //BEHAVIOURS 
    
    void Move(){
        Vector3 vel = rb.velocity;
        if(!active){
            if(Vector3.Distance(transform.position, player.transform.position) <= activationDistance){
                this.Activate();
                vel.x = rb.velocity.x;
                vel.y = rb.velocity.y;
                active = true;
            }
            vel.z = -(player.speed.z);
        }
        else{
            vel.z = -(player.speed.z + speed.z);
        }
        rb.velocity = vel;
    }
    
    public void computeSpeed(){
        speed = baseSpeed + additionalSpeed;
    }
    
    void Activate(){
        rb.velocity = speed;
    }
    
   void defaultDestroyCheck(){
        if(this.healthPoints <= 0F){
            //if an explosion effect is set, play it
	        if(deathExplosion != null){
	            Instantiate(deathExplosion, transform.position, transform.rotation);
            }
            //destroy gameobject
            Destroy(this.gameObject);
            if(gameController.spawnFuel())
                Instantiate(fuelObject, transform.position, transform.rotation);
        }
	}
    
    //COLLISION HANDLERS
    
    void OnCollisionEnter(Collision coll){
	    if(coll.collider.gameObject.CompareTag("Player"))
	        coll.collider.gameObject.GetComponent<PlayerController>().TakeDamage(damage);	        
	}
	
	void OnTriggerEnter(Collider coll){
	    if(coll.gameObject.CompareTag("PlayerProjectile")){
	        if(!invincible)
	            healthPoints -= 1F;
	        Destroy(coll.gameObject);
	    }
	    else if(coll.gameObject.CompareTag("Explosion"))
	        healthPoints -= 6F;
    }
    
    
}
