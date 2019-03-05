using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWall : MonoBehaviour
{

    public Vector3 movingSpeed;
    
    // Update is called once per frame
    void Update()
    {
        transform.Translate(movingSpeed * Time.deltaTime);
    }
    
    void OnTriggerEnter(Collider coll){
        if(coll.gameObject.CompareTag("MovingWallInverter")){
            movingSpeed = -movingSpeed;
        }
    }
}
