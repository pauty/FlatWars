using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseBehaviour : MonoBehaviour
{

    public float baseSpeed = 10F;
    public float additionalSpeed = float.MinValue;
    public float additionalSpeedMin = -20F;
    public float additionalSpeedMax = 20F;
    public float activationDistance = 500F;
    public float chaseProbability = 0.1F;
    float chaseSpeed = 2.4F;
    public bool canChase = true;
    bool isChasing;
    float speed;
    Rigidbody rb;
    PlayerController player;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
		player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
		if(additionalSpeed == float.MinValue)
		    additionalSpeed = Random.Range(additionalSpeedMin, additionalSpeedMax);
		if(canChase)
		    isChasing = Random.Range(0F, 1F) <= chaseProbability ? true : false;
		else
		    isChasing = false;
		computeSpeed();       
    }
    
    public void computeSpeed(){
        speed = baseSpeed + additionalSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, player.gameObject.transform.position) > activationDistance){
            rb.velocity = new Vector3(0, 0, -player.speed);
        }
        else{
            if(isChasing){
                float velX, velY;
                if(player.transform.position.x < transform.position.x)
                    velX = -chaseSpeed;
                else
                    velX = chaseSpeed;
                if(player.transform.position.y < transform.position.y)
                    velY = -chaseSpeed;
                else
                    velY = chaseSpeed;
                
                rb.velocity = new Vector3(velX, velY, -(player.speed + speed));
            }
            else
                rb.velocity = new Vector3(0, 0, -(player.speed + speed));
        }
    }
}
