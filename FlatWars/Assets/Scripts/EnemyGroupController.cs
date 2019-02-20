using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroupController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EnemyBaseBehaviour enemy;
        Vector3 commonBaseSpeed = Vector3.zero;
        Vector3 commonAdditionalSpeed = Vector3.zero;
        bool isFirst = true;
        for(int i = 0; i < this.gameObject.transform.childCount; i++){
            enemy = this.gameObject.transform.GetChild(i).GetComponent<EnemyBaseBehaviour>();
            if(enemy != null){
                if(isFirst){
                    commonBaseSpeed = enemy.baseSpeed;
                    commonAdditionalSpeed.x = 0F;
                    commonAdditionalSpeed.y = 0F;
                    commonAdditionalSpeed.z = Random.Range(enemy.additionalSpeedMin.z, enemy.additionalSpeedMax.z);
                    isFirst = false;
                }
                enemy.baseSpeed = commonBaseSpeed;
                enemy.additionalSpeed = commonAdditionalSpeed;
                enemy.computeSpeed();
            }           
        }
        transform.DetachChildren();
        Destroy(this.gameObject);
    }

}
