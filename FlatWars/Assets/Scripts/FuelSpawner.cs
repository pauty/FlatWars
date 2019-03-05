using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelSpawner : MonoBehaviour
{
    public float activationDistance = 300F;
    public GameObject fuelObject;
    public bool certainSpawn = false;
    public int minFuelNum = 2;
    public int maxFuelNum = 3;
    GameObject player;
    GameController gameController;
    BoxCollider box;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        box = gameObject.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, player.transform.position) < activationDistance){
            bool spawn = certainSpawn;
            if(!spawn)
                spawn = gameController.SpawnFuel();
            if(spawn){
                Vector3 pos;
                pos.x = Mathf.Lerp(box.bounds.min.x, box.bounds.max.x, Random.Range(0F,1F));
                pos.y = Mathf.Lerp(box.bounds.min.y, box.bounds.max.y, Random.Range(0F,1F));
                pos.z = Mathf.Lerp(box.bounds.min.z, box.bounds.max.z, Random.Range(0F,1F));
                int r = Random.Range(minFuelNum, maxFuelNum + 1);
                for(int i = 0; i < r; i++)
	                    Instantiate(fuelObject, pos + Random.onUnitSphere*2F, Random.rotation);
            }
            Destroy(this.gameObject);
        }
    }
}
