using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    
    float maxScale = 5F;
    float minScale = 1F;
    float openSpeed = 4F;
    float stopTime = .8F;
    float nextTime;
    bool isClosing = true;
    // Start is called before the first frame update
    void Start()
    {
        nextTime = Time.time + stopTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextTime){         
            Vector3 scaleV = new Vector3(openSpeed*Time.deltaTime, 0, 0);
            if(isClosing){
                transform.localScale = transform.localScale + scaleV;
                if(transform.localScale.x >= maxScale){
                    isClosing = false;
                    nextTime = Time.time + stopTime;
                }                 
            }
            else{
                transform.localScale = transform.localScale - scaleV;
                if(transform.localScale.x <= minScale){
                    isClosing = true;
                    nextTime = Time.time + stopTime;
                }
            }
        }       
    }
}
