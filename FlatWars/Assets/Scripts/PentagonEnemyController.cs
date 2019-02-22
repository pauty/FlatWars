using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PentagonEnemyController : MonoBehaviour
{

    public float visibilityInterval = 2F;
    Renderer visibleRenderer;
    Renderer invisibleRenderer;
    float nextTime;
    EnemyBaseBehaviour baseBehaviour;
    // Start is called before the first frame update
    void Start()
    {
        visibleRenderer = transform.Find("Mesh").GetComponent<Renderer>();
        invisibleRenderer = transform.Find("InvisibleMesh").GetComponent<Renderer>();
        visibleRenderer.enabled = true;
        invisibleRenderer.enabled = false;
        nextTime = Time.time + visibilityInterval;
        
        baseBehaviour = gameObject.GetComponent<EnemyBaseBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextTime){
            visibleRenderer.enabled = !visibleRenderer.enabled;
            invisibleRenderer.enabled = !invisibleRenderer.enabled;
            nextTime = Time.time + visibilityInterval;
            baseBehaviour.invincible = invisibleRenderer.enabled;
        }        
    }
}
