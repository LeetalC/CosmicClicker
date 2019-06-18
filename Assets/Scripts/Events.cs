using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Events : MonoBehaviour {

    public GameObject eventText;
    public GameObject supernovaText;

    public static Events Ev1;

    public static int passGasGen = 0;
    public static int passDustGen = 0;

    public static float seconds;

    //currently i have a starting value for seconds that doesn't change even if i
    //want the upgrade to change how quickly you gain gas. need to change
    private void Start()
    {
        seconds = 5.0f;
    }

    private void Update() {
        if (passGasGen != 0) {
            InvokeRepeating("PassiveGasGen", 1f, seconds);
            Debug.Log("here");
            this.enabled = false;
        }
    }

    public void PassiveGasGen() {
        CurrencyCollected.Instance.intGas += passGasGen;
    }
    public void SuperNovaText() {
      
        supernovaText.SetActive(true);
        supernovaText.GetComponent<TextMeshProUGUI>().text = "The star swells to 100x it's size...\nthen slowly and gently releases it's gasses...\nrevealing bits of dust!\nA new discovery!";
        supernovaText.GetComponent<Animation>().Play("EventAnim3");
    }

}