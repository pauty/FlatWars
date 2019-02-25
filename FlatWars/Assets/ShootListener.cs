using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShootListener : MonoBehaviour
{
    public enum actionEnum{
        start,
        quit
    };
    public actionEnum action = actionEnum.start;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider coll){
        if(coll.gameObject.CompareTag("PlayerProjectile")){
            switch(action){
                case actionEnum.start:
                    this.StartGame();
                    break;
                case actionEnum.quit:
                    this.QuitGame();
                    break;
            }           
        }
            
    }
    
    void StartGame(){
        SceneManager.LoadScene("Game");
    }
    
    void QuitGame(){
        Application.Quit();
        Debug.Log("Exiting");
    }
}
