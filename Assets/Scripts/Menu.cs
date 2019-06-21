using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject mainPanel;
    public GameObject planetPanel;
    public GameObject starsPanel;
    public GameObject settingsPanel;

    public GameObject settingsButton;
    public GameObject menuButton;

    public GameObject settingsButtonText;
    public GameObject menuButtonText;
    
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
 
    //called by the menu button
    public void changePanel(GameObject active, GameObject pOne, GameObject pTwo, GameObject pThree) {
        active.SetActive(true);
        pOne.SetActive(false);
        pTwo.SetActive(false);
        pThree.SetActive(false);
       // pFour.SetActive(false);
    }



    public void switchtomenu() {
        if (!menuPanel.activeInHierarchy)
        {
            settingsButton.SetActive(false);
            menuButtonText.GetComponent<TextMeshProUGUI>().text = "GO BACK";
            changePanel(menuPanel, mainPanel, planetPanel, settingsPanel);
        }
        else
        {
            settingsButton.SetActive(true);
            menuButtonText.GetComponent<TextMeshProUGUI>().text = "UPGRADES";
            changePanel(mainPanel, menuPanel, planetPanel, settingsPanel);
        }

    }

    public void switchtoplanets() {
        if (!planetPanel.activeInHierarchy) changePanel(planetPanel, mainPanel, menuPanel, settingsPanel);
        else changePanel(mainPanel, menuPanel, planetPanel, settingsPanel);
    }
    public void switchtosettings() {
        if (!settingsPanel.activeInHierarchy)
        {
            menuButton.SetActive(false);
            settingsButtonText.GetComponent<TextMeshProUGUI>().text = "GO BACK";
            changePanel(settingsPanel, mainPanel, menuPanel, planetPanel);
        }
        else
        {
            menuButton.SetActive(true);
            settingsButtonText.GetComponent<TextMeshProUGUI>().text = "SETTINGS";
            changePanel(mainPanel, menuPanel, planetPanel, settingsPanel);
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

