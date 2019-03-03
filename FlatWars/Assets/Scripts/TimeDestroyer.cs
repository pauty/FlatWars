using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDestroyer : MonoBehaviour
{
    public float timeToLive = 3;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, timeToLive);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
