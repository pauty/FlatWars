using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereExplosionController : MonoBehaviour
{

    public float maxRadius = 7F;
    public float explosionSpeed = 3F;
    float currentScale;
    
    // Start is called before the first frame update
    void Start()
    {
        currentScale = 1F;
    }

    // Update is called once per frame
    void Update()
    {
        currentScale += explosionSpeed*Time.deltaTime;
        transform.localScale = new Vector3 (currentScale, currentScale, currentScale);
        if(currentScale >= maxRadius){
            Destroy(this.gameObject);
        }
    }
}
