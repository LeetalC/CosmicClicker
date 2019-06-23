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

    void FixedUpdate()
    {
        //displays the gas and dust on the screen
        gasDisplayText.text = "Gas: " + intGas;
        dustDisplayText.text = "Dust: " + intDust;

        //so long as u have 20 gas you will see the make star button
        if (intGas >= 50) starButton.SetActive(true);
        else starButton.SetActive(false);
    }
}
