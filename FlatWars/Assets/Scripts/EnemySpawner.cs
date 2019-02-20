using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject[] EnemyPrefabs = new GameObject[3];
    public int enemyIndex = -1;
    
	// Use this for initialization
	void Start () {	    
	    int idx;
	    if(enemyIndex >= 0)
	        idx = enemyIndex;
	    else
	        idx = Random.Range(0, EnemyPrefabs.Length);
	        
	    Quaternion rot = Random.Range(0, 2) == 0 ? Quaternion.identity : Quaternion.Euler(0, 0, 90);
	    Instantiate(EnemyPrefabs[idx], transform.position, rot);	
	}
	
}
