using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    
public class NamedRandomizable{
    public string name;
    public float probabilityWeight;
    
    public static int GetRandomIdx(NamedRandomizable[] rands){
        float total = 0;
        for(int i = 0; i < rands.Length; i++)
            total += rands[i].probabilityWeight;
        
        float r = Random.Range(0F, total-0.0001F);
        
        total = rands[0].probabilityWeight;
        int idx = 0;
        while(total <= r && idx < rands.Length-1){
            idx++;
            total += rands[idx].probabilityWeight;
        }
        return idx;   
    }
}

[System.Serializable]
public class HazardFamily : NamedRandomizable{    
    public GameObject[] prefabs = new GameObject[3];    
}

[System.Serializable]
public class SpawnMode : NamedRandomizable{
    public float[] probabilities = new float[4];
}

public class HazardSpawner: MonoBehaviour {
    public PrismaBuilder tunnel; 
    
    public HazardFamily[] hazardFamilies = new HazardFamily[3];
    public SpawnMode[] spawnModes = new SpawnMode[4]; 
    public float changeModeIntervalMin = 10F;
    public float changeModeIntervalMax = 10F;
    public float spawnIntervalMin = 1F;
    public float spawnIntervalMax = 1F;
    float nextSpawnTime;
    float nextChangeTime;
    bool triggerChecked = true;
    
    float[] currentProbabilities = null;
    int currentModeIdx = -1;
    
	// Use this for initialization
	void Start () {
	    nextSpawnTime = Time.time + spawnIntervalMin;
	    nextChangeTime = Time.time + changeModeIntervalMin;
	    this.changeHazardProbabilities();

	}  
	
	void changeHazardProbabilities(){
	    int newModeIdx = NamedRandomizable.GetRandomIdx(spawnModes);
	    if(newModeIdx == currentModeIdx)
	        newModeIdx = (newModeIdx+1) % spawnModes.Length;
	    currentModeIdx = newModeIdx;
	    currentProbabilities = spawnModes[newModeIdx].probabilities;        
        for(int i = 0; i < hazardFamilies.Length; i++){
            if(i < currentProbabilities.Length)
                hazardFamilies[i].probabilityWeight = currentProbabilities[i];
            else
                hazardFamilies[i].probabilityWeight = 0F;
        }
	}
    	
	// Update is called once per frame
	void Update () {
	
	    if(Time.time >= nextChangeTime){
	        this.changeHazardProbabilities();
	        nextChangeTime = Time.time + Random.Range(changeModeIntervalMin, changeModeIntervalMax);
	    }
	    
		if(Time.time >= nextSpawnTime && triggerChecked){
		    GameObject[] hazardPrefabs = hazardFamilies[NamedRandomizable.GetRandomIdx(hazardFamilies)].prefabs;
		    
		    int r = Random.Range(0, hazardPrefabs.Length);

		    GameObject hazard = Instantiate(hazardPrefabs[r], transform.position, Quaternion.identity);
		    Transform wallScaleX = null;
		    Transform wallScaleY = null;
		    Transform wallScaleXY = null;
		    //
		    r = Random.Range(0, 4);
		    switch(r){
		        case 0:
		            //DO NOTHING, NO ROTATION
		            break;
		        case 1:
		            hazard.transform.Rotate(new Vector3(0,0,180));
		            break;
		        case 3:
		            hazard.transform.Rotate(new Vector3(0,0,90));
		            break;
		        case 4: 
		            hazard.transform.Rotate(new Vector3(0,0,-90));
		            break;
		    }
		    float scaleX = tunnel.widthSteps*tunnel.sectorWidth/10;
		    float scaleY = tunnel.heightSteps*tunnel.sectorHeight/10;
		    if(r >= 3){
		        //swap
		        float tmp = scaleX;
		        scaleX = scaleY;
		        scaleY = tmp;
		    }

		    wallScaleX = hazard.transform.Find("ScaleX");
		    if(wallScaleX != null){
		        wallScaleX.transform.localScale = new Vector3(scaleX, 1, 1);
		    }
		    wallScaleY = hazard.transform.Find("ScaleY");
		    if(wallScaleY != null){
		        wallScaleY.transform.localScale = new Vector3(1, scaleY, 1);
		    }
		    wallScaleXY = hazard.transform.Find("ScaleXY");
		    if(wallScaleXY != null){
		        wallScaleXY.transform.localScale = new Vector3(scaleX, scaleY, 1);
		    }
		    hazard.transform.localScale = new Vector3(1, 1, tunnel.sectorDepth/10);
		   
		    triggerChecked = false;
		}
	}
	
	
	void OnTriggerEnter(Collider coll){
	    nextSpawnTime = Time.time + Random.Range(spawnIntervalMin, spawnIntervalMax);
	    triggerChecked = true;
	}
	
	void OnTriggerStay(Collider coll){
	    nextSpawnTime = Time.time + Random.Range(spawnIntervalMin, spawnIntervalMax);
	    triggerChecked = true;
	}
	
}
