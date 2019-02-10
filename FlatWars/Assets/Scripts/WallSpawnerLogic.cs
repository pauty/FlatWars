using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawnerLogic : MonoBehaviour {
    
    public GameManagerLogic gameManager;
    public GameObject[] WallSetPrefabs = new GameObject[3];
    public float timeInterval = 14f;
    public float nextTime;
	// Use this for initialization
	void Start () {
	    nextTime = Time.time + timeInterval;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time >= nextTime){
		    int i = Random.Range(0, WallSetPrefabs.Length);
		    GameObject wall = Instantiate(WallSetPrefabs[i], transform.position, Quaternion.identity);
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
		    float scaleX = gameManager.tunnelWidthSteps*gameManager.tunnelSectorWidth;
		    float scaleY = gameManager.tunnelHeightSteps*gameManager.tunnelSectorHeight;
		    if(r >= 3){
		        //swap
		        float tmp = scaleX;
		        scaleX = scaleY;
		        scaleY = tmp;
		    }
		    wall.transform.localScale = new Vector3(scaleX, scaleY, gameManager.tunnelSectorDepth);
		    nextTime = Time.time + timeInterval;  
		}
	}
	
	void spawnWallSet(){
	    
	}
}
