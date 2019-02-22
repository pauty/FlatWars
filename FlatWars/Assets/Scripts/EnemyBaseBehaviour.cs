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
    
    [Header("Healt Settings")]
    public float lifePoints = 2F;
    public bool invincible = false;
    public bool delegateDestroy = false;
    public GameObject deathExplosion = null;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
		player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
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
        if(this.lifePoints <= 0F){
            //if an explosion effect is set, play it
	        if(deathExplosion != null){
	            GameObject explosion = Instantiate(deathExplosion, transform.position, transform.rotation) as GameObject;
                ParticleSystem parts = explosion.GetComponent<ParticleSystem>();
                float totalDuration = parts.duration + parts.startLifetime;
                Destroy(explosion, totalDuration);
            }
            //destroy gameobject
            Destroy(this.gameObject);
        }
	}
    
    //COLLISION HANDLERS
    
    void OnCollisionEnter(Collision coll){
	    if(coll.collider.gameObject.CompareTag("Player"))
	        Debug.Log("player hit");	        
	}
	
	void OnTriggerEnter(Collider coll){
	    if(coll.gameObject.CompareTag("PlayerProjectile")){
	        if(!invincible)
	            lifePoints -= 1F;
	        Destroy(coll.gameObject);
	    }
	    else if(coll.gameObject.CompareTag("Explosion"))
	        lifePoints -= 6F;
    }
    
    
}
