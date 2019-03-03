using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShoot : MonoBehaviour
{

    public GameObject projectile;
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = gameObject.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire")){
            Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
            Vector3 pos = new Vector3(transform.position.x, transform.position.y-2, transform.position.z+10);
;           Instantiate(projectile, pos, Quaternion.LookRotation(ray.direction));
        }
    }
}
