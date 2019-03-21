using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    
    LineRenderer lr;
    LayerMask layerMask = -1;
    public float collisionRadius = 0.3F;
    public float damage = 5F;
    float maxCastDistance = 50F;
    // Start is called before the first frame update
    void Start()
    {
        lr = gameObject.GetComponent<LineRenderer>();       
    }

    // Update is called once per frame
    void Update()
    {    
        RaycastHit hit;
        Vector3 dir;
        
        dir = -transform.right;
        if (Physics.SphereCast(transform.position, collisionRadius, dir, out hit, maxCastDistance, layerMask.value, QueryTriggerInteraction.Ignore)){
            lr.SetPosition(0, hit.distance*Vector3.left);    
            if(hit.transform.CompareTag("Player")){
                hit.transform.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
            }
        }
        
        dir = transform.right;
        if (Physics.SphereCast(transform.position, collisionRadius, dir, out hit, maxCastDistance, layerMask.value, QueryTriggerInteraction.Ignore)){
            lr.SetPosition(1, hit.distance*Vector3.right);
            if(hit.transform.CompareTag("Player")){
                hit.transform.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
            }
        }

        
        
    }
}
