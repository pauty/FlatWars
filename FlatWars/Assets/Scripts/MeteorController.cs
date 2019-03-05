using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorController : MonoBehaviour
{
    public GameObject[] meteorPrefabs = new GameObject[2];
    public GameObject finalExplosion = null;
    public float minScale = 2F;
    public float maxScale = 6F;
    public int minChildren = 2;
    public int  maxChildren = 4;
    bool dead = false;
    
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
	    if(baseBehaviour.healthPoints <= 0F && !dead){
	        this.SplitAndDestroy(); 	
	        dead = true;
	    }        
	}
	
	void SplitAndDestroy(){
        GameObject childObject;
        MeteorController childMeteor;
        if(this.maxScale > this.minScale){
            int r = Random.Range(minChildren, maxChildren+1);
            //int idx;
            for(int i = 0; i < r; i++){
        	    childObject = Instantiate(meteorPrefabs[0], transform.position + Random.onUnitSphere*2.5F, Random.rotation);
        	    childMeteor = childObject.GetComponent<MeteorController>();
        	    childMeteor.maxScale = Mathf.Max(childMeteor.minScale, this.scale - 1.5F);           	    
            }
            AudioSource audiosource = gameObject.GetComponent<AudioSource>();
            //gameObject.GetComponent<SphereCollider>().enabled = false;
            transform.Find("Mesh").GetComponent<MeshRenderer>().enabled = false;
            audiosource.Play();
            Destroy(this.gameObject, audiosource.clip.length);
        }
        else{
            if(finalExplosion != null)
                Instantiate(finalExplosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        if(gameController.SpawnFuel()){
	        for(int i = 0; i < 3; i++)
	            Instantiate(baseBehaviour.fuelObject, transform.position + Random.onUnitSphere*2F, Random.rotation);
	    }  
   
	}

}
