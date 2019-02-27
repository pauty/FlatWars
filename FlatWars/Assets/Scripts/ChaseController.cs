using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseController : MonoBehaviour
{
    public float chaseProbability = 0.1F;
    public float maxChaseDistance = 400F;
    public float minChaseDistance = 1F;
    public float maxChaseSpeed = 30F;
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
    void Update()
    {
        if(isChasing){
            Vector3 v = player.transform.position - transform.position;
            if(minChaseDistance < v.magnitude && v.magnitude < maxChaseDistance){
                //chaseSpeed = Mathf.Min(maxChaseSpeed, chaseSpeed + chaseSpeedIncrement*Time.deltaTime);                              
                Vector3 vel = rb.velocity;
                vel.x = v.x * maxChaseSpeed /  v.magnitude;
                vel.y = v.y * maxChaseSpeed /  v.magnitude;
                rb.velocity = vel;
                
                /*float xForce = v.x * chaseSpeed / Mathf.Max(1F, v.magnitude);
                float yForce = v.y * chaseSpeed / Mathf.Max(1F, v.magnitude);
                rb.AddForce(new Vector3(xForce, yForce, 0F));*/
               
            }
            else{ 
                //chaseSpeed = Mathf.Max(0F, chaseSpeed - chaseSpeedIncrement*Time.deltaTime);
            }
            
            
        }
    }
}
