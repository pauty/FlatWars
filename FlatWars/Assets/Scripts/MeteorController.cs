using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorController : MonoBehaviour
{
    public GameObject[] meteorPrefabs = new GameObject[2];
    public GameObject finalExplosion = null;
    public float minScale = 2F;
    public float maxScale = 6F;
    float scale;
    EnemyBaseBehaviour baseBehaviour;
    GameController gameController;
    
    // Start is called before the first frame update
    void Start()
    {
        scale = Random.Range(minScale, maxScale);
        transform.localScale = new Vector3(scale, scale, scale);
        baseBehaviour = gameObject.GetComponent<EnemyBaseBehaviour>();
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }

	void Update(){
	    if(baseBehaviour.healthPoints <= 0F)
	        this.SplitAndDestroy(); 	        
	}
	
	void SplitAndDestroy(){
        GameObject childObject;
        MeteorController childMeteor;
        if(this.maxScale > this.minScale){
            int r = Random.Range(0, 3) + 2;
            //int idx;
            Vector3 spawnPos = transform.position;
            for(int i = 0; i < r; i++){
                //spawnPos.x = transform.position.x + (i-2)*2F; 
                //spawnPos.y = transform.position.y + (i-2)*2F;
                spawnPos.z = transform.position.z + (i-2)*2F;
                //idx = Random.Range(0, meteorPrefabs.Length);
        	    childObject = Instantiate(meteorPrefabs[0], spawnPos, Quaternion.identity);
        	    childMeteor = childObject.GetComponent<MeteorController>();
        	    childMeteor.maxScale = Mathf.Max(childMeteor.minScale, this.scale - 1.5F);          	    
            }
        }
        else{
            if(finalExplosion != null)
                Instantiate(finalExplosion, transform.position, Quaternion.identity);
        }
        if(gameController.spawnFuel()){
	        Instantiate(baseBehaviour.fuelObject, transform.position, transform.rotation);
	    }
        Destroy(this.gameObject);     
	}

}
