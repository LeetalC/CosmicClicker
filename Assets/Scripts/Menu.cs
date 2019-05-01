using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public CurrencyCollected currencyColl;
    public GameObject PlanetButton;
    public bool planetbuttonUnlocked = false;
    public void unlockplanetbutton() {
        PlanetButton.SetActive(false);
    }
    void Start() {
        unlockplanetbutton();
    }

    public void switchtomenu() {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MenuScene")) {
            SceneManager.LoadScene("MainScene");
        }
        else {
            SceneManager.LoadScene("MenuScene");
        }
    }
    public void switchtoplanets() {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainScene")) {
            SceneManager.LoadScene("PlanetMenuScene");
        }
        else {
            SceneManager.LoadScene("MainScene");
        }
    }
    public void Update() {

        if (planetbuttonUnlocked == false && currencyColl.intGas >= 500 && CurrencyCollected.dustCount >= 190) {
            PlanetButton.SetActive(true);
            planetbuttonUnlocked = true;
        }
            
        if (Input.GetKeyDown("1")) {
            SceneManager.LoadScene("MainScene");
        }
        else if (Input.GetKeyDown("2")) {
            SceneManager.LoadScene("MenuScene");
        }
        else if (Input.GetKeyDown("3")) {
            SceneManager.LoadScene("PlanetMenuScene");
        }
    }
}

