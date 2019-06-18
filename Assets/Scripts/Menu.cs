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
 
    //called by the menu button
    public void changePanel(GameObject active, GameObject pOne, GameObject pTwo, GameObject pThree) {
        active.SetActive(true);
        pOne.SetActive(false);
        pTwo.SetActive(false);
        pThree.SetActive(false);
       // pFour.SetActive(false);
    }



    public void switchtomenu() {
        if (!menuPanel.activeInHierarchy) changePanel(menuPanel, mainPanel, planetPanel, settingsPanel);
        else changePanel(mainPanel, menuPanel, planetPanel, settingsPanel);

    }

    public void switchtoplanets() {
        if (!planetPanel.activeInHierarchy) changePanel(planetPanel, mainPanel, menuPanel, settingsPanel);
        else changePanel(mainPanel, menuPanel, planetPanel, settingsPanel);
    }
    public void switchtosettings() {
        if (!settingsPanel.activeInHierarchy) changePanel(settingsPanel, mainPanel, menuPanel, planetPanel);
        else changePanel(mainPanel, menuPanel, planetPanel, settingsPanel);

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

