using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIController : MonoBehaviour
{
     public GameObject pauseFirstSelection;
     public GameObject gameoverFirstSelection;
     GameObject selectedObj;
     public Image playerHealthImage; 
     public GameObject pauseMenuPanel = null;
     public GameObject gameOverPanel = null;
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
         
         playerHealthImage.fillAmount = player.healthPoints/player.maxHealthPoints;
         
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
            if(show)
                EventSystem.current.SetSelectedGameObject(gameoverFirstSelection);
     }
     
 }
