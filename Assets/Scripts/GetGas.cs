﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GetGas : MonoBehaviour {

    public CurrencyCollected currencyColl;
    public GameObject gasGainedText;
    public GameObject harvestGasText;
    public static int gasPerClick = 40;    

  
    public void GainGas() {
        gasGainedText.GetComponent<Animation>().Stop("GainGasAnim");
        currencyColl.intGas += gasPerClick;
        //gasGainedText.GetComponent<Text>().text = ("+" + gasPerClick);
        gasGainedText.GetComponent<TextMeshProUGUI>().text = ("+" + gasPerClick);
        gasGainedText.GetComponent<Animation>().Play("GainGasAnim");

    }
}
