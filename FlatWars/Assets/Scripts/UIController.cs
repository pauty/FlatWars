using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class UIController : MonoBehaviour
{
     public GameObject pauseFirstSelection;
     public GameObject gameoverFirstSelection;
     GameObject selectedObj;
     public Image playerHealthImage = null; 
     public Color highHealthColor;
     public Color lowHealthColor;
     public Color criticalHealthColor;
     public GameObject pauseMenuPanel = null;
     public GameObject gameOverPanel = null;
     public TextMeshProUGUI inGameScoreText = null;
     public TextMeshProUGUI gameOverScoreText = null;
     PlayerController player;
 
     void Start()
     {
        //EventSystem.current.SetSelectedGameObject(selectedObj);
        selectedObj = EventSystem.current.currentSelectedGameObject;
        this.ShowPauseMenu(false);
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
     }
 
     void Update()
     {
         if (EventSystem.current.currentSelectedGameObject == null)
             EventSystem.current.SetSelectedGameObject(selectedObj);
     
         selectedObj = EventSystem.current.currentSelectedGameObject;

         if(playerHealthImage != null){
            float healthPercent = player.healthPoints/player.maxHealthPoints;
            playerHealthImage.fillAmount = healthPercent;
            if(healthPercent > 0.30F){
                playerHealthImage.color = highHealthColor;
            }
            else if(healthPercent > 0.15F){
                playerHealthImage.color = lowHealthColor;
            }
            else{
                playerHealthImage.color = criticalHealthColor;
            }
         }
         
         if(inGameScoreText !=  null)
            inGameScoreText.text = ((int)player.totalDistance).ToString() + " m";
         
     }
     
     
     public void ShowPauseMenu(bool show){
        if(pauseMenuPanel != null){
            pauseMenuPanel.SetActive(show);   
            EventSystem.current.SetSelectedGameObject(null);
            if(show)
                EventSystem.current.SetSelectedGameObject(pauseFirstSelection);
            
        } 
           
     }
     
     public void ShowGameOver(bool show){
        if(gameOverPanel != null)
            gameOverPanel.SetActive(show);    
            EventSystem.current.SetSelectedGameObject(null);
            if(show){
                EventSystem.current.SetSelectedGameObject(gameoverFirstSelection);
                inGameScoreText.enabled = false;
                if(gameOverScoreText.text  != null)
                    gameOverScoreText.text = "Final Score: " + inGameScoreText.text;
            }
            else
                inGameScoreText.enabled = true;
     }
     
 }
