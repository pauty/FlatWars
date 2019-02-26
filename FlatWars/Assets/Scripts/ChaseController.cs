using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseController : MonoBehaviour
{
    public float chaseProbability = 0.1F;
    public float maxChaseSpeed = 2.4F;
    public float chaseSpeedIncrement = 1F;
    public float maxChaseDistance = 400F;
    public float minChaseDistance = 1F;
    Vector3 chaseSpeed;
    bool isChasing;
    Rigidbody rb;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        isChasing = Random.Range(0F, 1F) < chaseProbability ? true : false;
        rb = gameObject.GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isChasing){
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if(minChaseDistance < distance && distance < maxChaseDistance){ 
                if(player.transform.position.x > transform.position.x)
                    chaseSpeed.x = Mathf.Min(maxChaseSpeed, chaseSpeed.x + chaseSpeedIncrement*Time.deltaTime);
                else if(player.transform.position.x < transform.position.x)
                    chaseSpeed.x = Mathf.Max(-maxChaseSpeed, chaseSpeed.x - chaseSpeedIncrement*Time.deltaTime);
                    
                if(player.transform.position.y > transform.position.y)
                    chaseSpeed.y = Mathf.Min(maxChaseSpeed, chaseSpeed.y + chaseSpeedIncrement*Time.deltaTime);
                else if(player.transform.position.y < transform.position.y)
                    chaseSpeed.y = Mathf.Max(-maxChaseSpeed, chaseSpeed.y - chaseSpeedIncrement*Time.deltaTime);
                    
                Vector3 vel = rb.velocity;
                vel.x = chaseSpeed.x;
                vel.y = chaseSpeed.y;
                rb.velocity = chaseSpeed;
            }
            
        }
    }
}
