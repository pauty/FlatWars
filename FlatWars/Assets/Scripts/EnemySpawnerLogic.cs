using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerLogic : MonoBehaviour {
    public enum SpawnGroupEnum{
        yes,
        no,
        random
    };
    public SpawnGroupEnum spawnGroup = SpawnGroupEnum.no;
    public bool isGroupUniform = false;
    public GameObject[] EnemyPrefabs = new GameObject[3];
    public int enemyIndex = -1;
    
	// Use this for initialization
	void Start () {
	    int i, j, k;
	    if(enemyIndex >= 0)
	        i = enemyIndex;
	    else
	        i = Random.Range(0, EnemyPrefabs.Length);
	    
	    if(spawnGroup == SpawnGroupEnum.random)
	        spawnGroup = Random.Range(0, 10) >= 5 ? SpawnGroupEnum.yes : SpawnGroupEnum.no;
	    
	    Vector3 pos = transform.position;
	    Quaternion rot = Random.Range(0, 10) >= 5 ? Quaternion.identity : Quaternion.Euler(0, 0, 90);
	    
	    Instantiate(EnemyPrefabs[i], pos, rot);
	    
	    if(spawnGroup == SpawnGroupEnum.yes){
	        
	        if(!isGroupUniform){
                j = Random.Range(0, EnemyPrefabs.Length);
                k = Random.Range(0, EnemyPrefabs.Length);
	        }
	        else{
	         k = j = i;
	        }
            
            int r = Random.Range(0, 15);
	        if(r < 5){
	            //HORIZONTAL DISPLACEMENT
	            pos.x += 4;
	            Instantiate(EnemyPrefabs[j], pos, rot);
	            pos.x -= 8;
	            Instantiate(EnemyPrefabs[k], pos, rot);
	        }
	        else if(r > 9){
	            //VERTICAL DISPLACEMENT
	            pos.y += 4;
	            Instantiate(EnemyPrefabs[j], pos, rot);
	            pos.y -= 8;
	            Instantiate(EnemyPrefabs[k], pos, rot);
	        }
	        else{
	            //DEPTH DISPLACEMENT
	            pos.z += 4;
	            Instantiate(EnemyPrefabs[j], pos, rot);
	            pos.z -= 8;
	            Instantiate(EnemyPrefabs[k], pos, rot);
	        }
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
