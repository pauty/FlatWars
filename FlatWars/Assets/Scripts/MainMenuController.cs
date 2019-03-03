﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenuController : MonoBehaviour
{
     GameObject selectedObj;
     void Start()
     {
        selectedObj = EventSystem.current.currentSelectedGameObject;
     }
 
     void Update()
     {
         if (EventSystem.current.currentSelectedGameObject == null)
             EventSystem.current.SetSelectedGameObject(selectedObj);
     
         selectedObj = EventSystem.current.currentSelectedGameObject;    
     }
    
    public void StartGame(){
        SceneManager.LoadScene("Game");
    }
    
    public void QuitGame(){
        Application.Quit();
        Debug.Log("Exiting");
    }
}
