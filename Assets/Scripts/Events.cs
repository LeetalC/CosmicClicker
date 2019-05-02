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

    private void Start() {
        if (passGasGen != 0) {
            InvokeRepeating("PassiveGasGen", 1.0f, 1.0f);
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