using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroupController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EnemyBaseBehaviour enemy;
        float commonBaseSpeed = 0F;
        float commonAdditionalSpeed = 0F;
        bool isFirst = true;
        for(int i = 0; i < this.gameObject.transform.childCount; i++){
            enemy = this.gameObject.transform.GetChild(i).GetComponent<EnemyBaseBehaviour>();
            if(enemy != null){
                if(isFirst){
                    commonBaseSpeed = enemy.baseSpeed;
                    commonAdditionalSpeed = Random.Range(enemy.additionalSpeedMin, enemy.additionalSpeedMax);
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
