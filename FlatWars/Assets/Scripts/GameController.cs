using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    
    
    public UIController UI;
    public float spawnFuelProbabilityIncrement = 0.1F;
    public float spawnFuelProbabilityDecrementRate = 2F;
    public float spawnFuelProbability = 0.5F;
    bool gamePaused = false;
    bool gameOver = false;
    
    PlayerController player;
    
	// Use this for initialization
	void Start () {        
        gamePaused = false;
        gameOver = false;
        UI.ShowPauseMenu(false);
        UI.ShowGameOver(false);
		player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
	    spawnFuelProbability = Mathf.Min(1F, spawnFuelProbability + spawnFuelProbabilityIncrement*Time.deltaTime);
	    
	    
	    if(!gameOver){
	        if(Input.GetButtonDown("Pause")){
	            if(!gamePaused){
                    this.PauseGame();
	            }
	            else{
	                this.ResumeGame();
	            }
	        }
	        
	        if(player.gameOverConditionReached){
	            this.GameOver();
	        }
	    }
		
	}
	
	public void PauseGame(){
	    Time.timeScale = 0F;
	    gamePaused = true;
	    player.enabled = false;
	    UI.ShowPauseMenu(true);
	}
	
	public void ResumeGame(){
	    Time.timeScale = 1F;
	    gamePaused = false;
	    player.enabled = true;
	    UI.ShowPauseMenu(false);
	}
	
	public void GameOver(){
	    gameOver = true;
	    Time.timeScale = 0F;
	    player.enabled = false;
	    UI.ShowGameOver(true);
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
