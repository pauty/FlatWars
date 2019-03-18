﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{

     public Image blackImage = null;
     
     public AudioClip mainMenuMusic;
     public AudioClip startGameClip;    
     AudioSource audiosource;
     
     GameObject selectedObj;
     bool started = false;
     bool readyToLoadGame;
     
     void Start()
     {
        selectedObj = EventSystem.current.currentSelectedGameObject;
        audiosource = gameObject.GetComponent<AudioSource>();
        audiosource.loop = true;
        audiosource.clip = mainMenuMusic;
        audiosource.Play();
        started = false;
        readyToLoadGame = false;
        
     }
 
     void Update()
     {
         if (EventSystem.current.currentSelectedGameObject == null)
             EventSystem.current.SetSelectedGameObject(selectedObj);
     
         selectedObj = EventSystem.current.currentSelectedGameObject;    
         
         if(readyToLoadGame)
            SceneManager.LoadScene("Game");
     }
    
    public void StartGame(){
        if(!started){
            started = true;
            audiosource.Stop();
            audiosource.loop = false;
            audiosource.clip = startGameClip;
            audiosource.Play();    
            StartCoroutine(FadeImage(3F, false));
        }
    }
    
    public void QuitGame(){
        Application.Quit();
        Debug.Log("Exiting");
    }
    
 
    private IEnumerator FadeImage(float fadeTime, bool fadeAway)
    {
        Color imgColor;
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = fadeTime; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                imgColor = blackImage.color;
                imgColor.a = i/fadeTime;
                blackImage.color = imgColor;
                yield return null;
            }
        }
        // fade from transparent to opaque
        else
        {
            // loop over 1 second
            for (float i = 0; i <= fadeTime; i += Time.deltaTime)
            {
                // set color with i as alpha
                imgColor = blackImage.color;
                imgColor.a = i/fadeTime;
                blackImage.color = imgColor;
                yield return null;
            }
        }
        
        readyToLoadGame = true;
    }
    
    
    
}
