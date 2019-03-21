using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    
    public enum EnemyType{
        standard,
        meteor
    }
    public EnemyType type = EnemyType.standard;
    public GameObject enemyToSpawn = null;
    public GameObject[] StandardEnemyPrefabs = new GameObject[3];
    public GameObject[] MeteorEnemyPrefabs = new GameObject[3];
 
	// Use this for initialization
	void Start () {	   
	    if(enemyToSpawn != null){
	        Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
	    }
	    else{
	        int idx;
	        switch(type){
	            case EnemyType.standard:
	                idx = Random.Range(0, StandardEnemyPrefabs.Length);	                
	                Quaternion rot = Random.Range(0, 2) == 0 ? Quaternion.identity : Quaternion.Euler(0, 0, 90);
	                Instantiate(StandardEnemyPrefabs[idx], transform.position, rot);
	                break;
	            case EnemyType.meteor:
	                idx = Random.Range(0, MeteorEnemyPrefabs.Length);     
	                Instantiate(MeteorEnemyPrefabs[idx], transform.position, Random.rotation);
	            	break;
	        }
	    }
	}
	
}
