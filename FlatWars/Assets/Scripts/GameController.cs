using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    
    bool gamePaused = false;
    public UIController UI;
    public float spawnFuelProbabilityIncrement = 0.1F;
    public float spawnFuelProbabilityDecrementRate = 2F;
    public float spawnFuelProbability = 0.5F;
    
	// Use this for initialization
	void Start () {        
        gamePaused = false;
		
	}
	
	// Update is called once per frame
	void Update () {
	    spawnFuelProbability = Mathf.Min(1F, spawnFuelProbability + spawnFuelProbabilityIncrement*Time.deltaTime);
	    
	    if(Input.GetButtonDown("Pause")){
	        if(!gamePaused){
                this.PauseGame();
	        }
	        else{
	            this.ResumeGame();
	        }
	    }
		
	}
	
	public void PauseGame(){
	    Time.timeScale = 0F;
	    gamePaused = true;
	    UI.ShowPauseMenu(true);
	}
	
	public void ResumeGame(){
	    Time.timeScale = 1F;
	    gamePaused = false;
	    UI.ShowPauseMenu(false);
	}
	
	public void RestartGame(){
	    this.ResumeGame();
	    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
	
	public void QuitGame(){
	    this.ResumeGame();
	    SceneManager.LoadScene("MainMenu");
	}
	
	public bool spawnFuel(){
	    bool spawn = Random.Range(0F, 1F) < spawnFuelProbability ? true : false;
	    if(spawn)
	        spawnFuelProbability = spawnFuelProbability/spawnFuelProbabilityDecrementRate;
	    return spawn;	        
	}
}
