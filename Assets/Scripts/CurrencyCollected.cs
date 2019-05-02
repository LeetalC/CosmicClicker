using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CurrencyCollected : SingletonOK<CurrencyCollected> {
    //PRIVATE VARIABLES
    public int intGas;
    public int intDust;
    //GAMEOBJS
    public GameObject starButton;
    public TextMeshProUGUI gasDisplayText;
    public TextMeshProUGUI dustDisplayText; 

    void Start() {
    }

    void FixedUpdate()
    {
        //displays the gas and dust on the screen
        gasDisplayText.text = "Gas: " + intGas + " tons.";
        dustDisplayText.text = "Dust: " + intDust + " tons.";

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainScene")) {
            if (intGas >= 20) {
                starButton.SetActive(true);
            }
            else {
                starButton.SetActive(false);
            }
        }
    }
}
