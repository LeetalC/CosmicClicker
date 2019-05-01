using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CurrencyCollected : MonoBehaviour
{
    //PRIVATE VARIABLES
    public static int gasCount;
    public static int dustCount;
    public int intGas;
    public int intDust;
    //GAMEOBJS
    public GameObject gasDisplay;
    public GameObject dustDisplay;
    public GameObject starButton;


    void FixedUpdate()
    {
        intGas = gasCount;
        intDust = dustCount;
        //displays the gas and dust on the screen
        gasDisplay.GetComponent<TextMeshProUGUI>().text = "Gas: " + intGas + " tons.";
        dustDisplay.GetComponent<TextMeshProUGUI>().text = "Dust: " + intDust + " tons.";
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainScene")) {
            if (gasCount >= 20) {
                starButton.SetActive(true);
            }
            else {
                starButton.SetActive(false);
            }
        }
    }
}
