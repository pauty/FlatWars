using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardSpawner: MonoBehaviour {
    
    public GameController gameController;
    public GameObject[] HazardPrefabs = new GameObject[3];
    public float timeInterval = 1f;
    float nextTime;
    bool triggerChecked = true;
	// Use this for initialization
	void Start () {
	    nextTime = Time.time + timeInterval;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Time.time >= nextTime && triggerChecked){
		    int i = Random.Range(0, HazardPrefabs.Length);
		    //i = 3;
		    GameObject wall = Instantiate(HazardPrefabs[i], transform.position, Quaternion.identity);
		    Transform wallScaleX = null;
		    Transform wallScaleY = null;
		    Transform wallScaleXY = null;
		    //
		    int r = Random.Range(0, 4);
		    switch(r){
		        case 0:
		            //DO NOTHING, NO ROTATION
		            break;
		        case 1:
		            wall.transform.Rotate(new Vector3(0,0,180));
		            break;
		        case 3:
		            wall.transform.Rotate(new Vector3(0,0,90));
		            break;
		        case 4: 
		            wall.transform.Rotate(new Vector3(0,0,-90));
		            break;
		    }
		    float scaleX = gameController.tunnelWidthSteps*gameController.tunnelSectorWidth/10;
		    float scaleY = gameController.tunnelHeightSteps*gameController.tunnelSectorHeight/10;
		    if(r >= 3){
		        //swap
		        float tmp = scaleX;
		        scaleX = scaleY;
		        scaleY = tmp;
		    }

		    wallScaleX = wall.transform.Find("ScaleX");
		    if(wallScaleX != null){
		        wallScaleX.transform.localScale = new Vector3(scaleX, 1, 1);
		    }
		    wallScaleY = wall.transform.Find("ScaleY");
		    if(wallScaleY != null){
		        wallScaleY.transform.localScale = new Vector3(1, scaleY, 1);
		    }
		    wallScaleXY = wall.transform.Find("ScaleXY");
		    if(wallScaleXY != null){
		        wallScaleXY.transform.localScale = new Vector3(scaleX, scaleY, 1);
		    }
		    wall.transform.localScale = new Vector3(1, 1, gameController.tunnelSectorDepth/10);
		   
		    //nextTime = Time.time + timeInterval;  
		    triggerChecked = false;
		}
	}
	
	void OnTriggerEnter(Collider coll){
	    nextTime = Time.time + timeInterval;
	    triggerChecked = true;
	}
	
	void OnTriggerStay(Collider coll){
	    nextTime = Time.time + timeInterval;
	    triggerChecked = true;
	}
	
}
