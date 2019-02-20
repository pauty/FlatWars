using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseBehaviour : MonoBehaviour
{

    public Vector3 baseSpeed = new Vector3(0F, 0F, 10F);
    public Vector3 additionalSpeed = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
    public Vector3 additionalSpeedMin = new Vector3(0F, 0F, -5F);
    public Vector3 additionalSpeedMax = new Vector3(0F, 0F, 5F);
    Vector3 speed;
    Rigidbody rb;
    PlayerController player;
    
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
    
    public void computeSpeed(){
        speed = baseSpeed + additionalSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vel = rb.velocity;
        vel.z = -(player.speed.z + speed.z);
        rb.velocity = vel;
    }
    
    void OnTriggerEnter(Collider coll){
        if(coll.gameObject.CompareTag("ActivationWall")){
            rb.velocity = speed;
        }
    }
}
