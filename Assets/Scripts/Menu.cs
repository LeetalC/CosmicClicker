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
    public GameObject starsPanel;
    public GameObject settingsPanel;

    public GameObject PlanetButton;
    public bool planetbuttonUnlocked = false;
    //Why did i need this?
    //public void unlockplanetbutton() {
    //    PlanetButton.SetActive(false);
    //}
    void Start() {
        starsPanel.SetActive(true);
        mainPanel.SetActive(true);
        menuPanel.SetActive(false);
        PlanetButton.SetActive(false);
       // unlockplanetbutton();
    }

    public void switchtomenu() {
        //if (!mainPanel.activeInHierarchy) {
        //    mainPanel.SetActive(true);
        //    menuPanel.SetActive(false);
        //    planetPanel.SetActive(false);

        //}
        //else
        //{
        //    menuPanel.SetActive(false);
        //}
        if (mainPanel.activeInHierarchy)
        {


            mainPanel.SetActive(false);
            menuPanel.SetActive(true);
        }
        else
        {
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
    public void switchtosettings() {
        if (mainPanel.activeInHierarchy)
        {
            settingsPanel.SetActive(true);
            mainPanel.SetActive(false);
        }
        else
        {
            settingsPanel.SetActive(false);
            mainPanel.SetActive(true);
        }

    }
    public void Update() {

        if (!planetbuttonUnlocked && CurrencyCollected.Instance.intGas >= 500 && CurrencyCollected.Instance.intDust >= 190) {
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

