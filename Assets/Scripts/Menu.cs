using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject mainPanel;
    public GameObject planetPanel;

    public GameObject PlanetButton;
    public bool planetbuttonUnlocked = false;
    public void unlockplanetbutton() {
        PlanetButton.SetActive(false);
    }
    void Start() {
        mainPanel.SetActive(true);
        menuPanel.SetActive(false);
        unlockplanetbutton();
    }

    public void switchtomenu() {
        if (mainPanel.activeInHierarchy) {
            mainPanel.SetActive(false);
            menuPanel.SetActive(true);
        }
        else {
            menuPanel.SetActive(false);
            mainPanel.SetActive(true);
        }
       
      
    }
    public void switchtoplanets() {
        if (mainPanel.activeInHierarchy) {
            mainPanel.SetActive(false);
            planetPanel.SetActive(true);
        }
        else {
            planetPanel.SetActive(false);
            menuPanel.SetActive(true);
            
        }
    }
    public void Update() {

        if (planetbuttonUnlocked == false && CurrencyCollected.Instance.intGas >= 500 && CurrencyCollected.Instance.intDust >= 190) {
            PlanetButton.SetActive(true);
            planetbuttonUnlocked = true;
        }
     
    }
}
//when I was using scenes instead of panels
/*  //if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MenuScene")) {
        //    SceneManager.LoadScene("MainScene");
        //}
        //else {
        //    SceneManager.LoadScene("MenuScene");
        //}
        
    if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainScene")) {
            SceneManager.LoadScene("PlanetMenuScene");
        }
        else {
            SceneManager.LoadScene("MainScene");
        }
     
     //in update
        if (Input.GetKeyDown("1")) {
            SceneManager.LoadScene("MainScene");
        }
        else if (Input.GetKeyDown("2")) {
            SceneManager.LoadScene("MenuScene");
        }
        else if (Input.GetKeyDown("3")) {
            SceneManager.LoadScene("PlanetMenuScene");
        }*/

