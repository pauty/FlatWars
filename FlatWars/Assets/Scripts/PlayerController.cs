using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    bool axisFreeX = true;
    bool axisFreeY = true;
    float nextTime;
    float timeInterval = 0.1F;
    bool go = true;
    public float projectileSpeed = 280;
    Rigidbody rb;
    Vector3 knockback;
    public GameObject projectile;
    
	// Use this for initialization
	void Start () {
		nextTime = Time.time;
		rb = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	     if(Input.GetKeyDown(KeyCode.JoystickButton0)){
	        //FIRE
	        GameObject p;
	        Vector3 pos = new Vector3(transform.position.x+1, transform.position.y, transform.position.z+10);
	        
	        p = Instantiate(projectile, pos, Quaternion.identity);	        
	        //p.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, projectileSpeed);
	        //Destroy(p, 10F);
	        
	        pos.x -= 2;
	        p = Instantiate(projectile, pos, Quaternion.identity);
	        //p.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, projectileSpeed);
	        //Destroy(p, 10F);
	        
	        
	        Debug.Log(0);
	     }
	     
	     if(Input.GetKeyDown(KeyCode.JoystickButton1))
	        Debug.Log(1);
	     if(Input.GetKeyDown(KeyCode.JoystickButton2))
	        Debug.Log(2);
	     if(Input.GetKeyDown(KeyCode.JoystickButton3))
	        Debug.Log(3);
	     if(Input.GetKeyDown(KeyCode.JoystickButton4))
	        Debug.Log(4);
	     if(Input.GetKeyDown(KeyCode.JoystickButton5))
	        Debug.Log(5);
	     
	     
	     
	     /*   
	     int xAxis = (int)Input.GetAxisRaw("DpadX");
         if(xAxis != 0 && axisFreeX){
            axisFreeX = false;
            if(xAxis == -1)
                transform.Translate(-5,0,0);
            else 
                transform.Translate(5,0,0);
         }
         else if(xAxis == 0)   
            axisFreeX = true;
            
         int yAxis = (int)Input.GetAxisRaw("DpadY");
         if(yAxis != 0 && axisFreeY){
            axisFreeY = false;
            if(yAxis == -1)
                transform.Translate(0,5,0);
            else 
                transform.Translate(0,-5,0);
         }
         else if(yAxis == 0)   
            axisFreeY = true;
         */
         
         /*
         if(Time.time >= nextTime || go){
            nextTime = Time.time + timeInterval;
            if(Input.GetAxisRaw("DpadX") == -1){
                //transform.Translate(-3,0,0);
                rb.MovePosition(new Vector3(transform.position.x - 3, transform.position.y ,transform.position.z));
            }
            else if(Input.GetAxisRaw("DpadX") == 1){
                //transform.Translate(3,0,0);
                 rb.MovePosition(new Vector3(transform.position.x +3, transform.position.y ,transform.position.z));
            }
            
            if(Input.GetAxisRaw("DpadY") == -1){
                //transform.Translate(0,3,0);
                rb.MovePosition(new Vector3(transform.position.x, transform.position.y +3,transform.position.z));
            }
            else if(Input.GetAxisRaw("DpadY") == 1){
                //transform.Translate(0,-3,0);
                 rb.MovePosition(new Vector3(transform.position.x, transform.position.y -3,transform.position.z));
            }
         }
         go = Input.GetAxisRaw("DpadX") == 0 && Input.GetAxisRaw("DpadY") == 0;
          */
         
         float dx = Input.GetAxis("JoyLX");
         float dy = Input.GetAxis("JoyLY");
         Vector3 movement = new Vector3(dx, -dy, 0f).normalized;
         rb.velocity = movement * 16 + knockback; 
         knockback = new Vector3(0,0,0);
         //rb.AddForce(new Vector3(0,dy*4,0));
	        

	      
	           
		
	}
	
    void OnCollisionStay(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            knockback = contact.normal * 40; 
        }

    }
}
