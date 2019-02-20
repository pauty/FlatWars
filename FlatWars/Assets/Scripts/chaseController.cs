using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chaseController : MonoBehaviour
{
    public float chaseProbability = 0.1F;
    float chaseSpeed = 2.4F;
    bool isChasing;
    // Start is called before the first frame update
    void Start()
    {
        isChasing = Random.Range(0F, 1F) < chaseProbability ? true : false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isChasing){
        }
    }
}
