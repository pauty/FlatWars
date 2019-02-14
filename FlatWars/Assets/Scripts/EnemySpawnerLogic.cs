using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerLogic : MonoBehaviour {

    public GameObject[] EnemyPrefabs = new GameObject[3];
	// Use this for initialization
	void Start () {
	    int i = Random.Range(0, EnemyPrefabs.Length);
		Instantiate(EnemyPrefabs[i], transform.position, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
