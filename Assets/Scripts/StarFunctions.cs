using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StarFunctions : MonoBehaviour
{
    public GameObject starButton;
    public StarTimer mytimer;
    public Sounds supernovaSound;
    public int intdustGained = 0;
    public bool timesped = false;

    public static int dustGained;
    public static int getDustGained() {
        return dustGained;
    }

   // public GameObject supernova;
    public static bool superNovaHappened = false;

    private void Update() {
        if (mytimer.GetlifeTime() <= 0) {
            SupernovaEvent();
        }
    }
    public void SupernovaEvent() {
        starButton.SetActive(false);
        MakeStar.currStarCount--;

        if (timesped == false) intdustGained = Random.Range(5, 20);
        else {
            if (starButton.tag == "BlueStar") intdustGained = Random.Range(100, 1000);
            else intdustGained = Random.Range(10, 100);
            timesped = false;
            CurrencyCollected.Instance.intDust += intdustGained;
        }
        dustGained = intdustGained;
        supernovaSound.playSuperNovaSound();
        superNovaHappened = true;
        TurnOff();
    }

    public void SpeedTime() {
        mytimer.SetLifeTime(-1);
        timesped = true;
    }

    public void TurnOff() {
        this.enabled = false;
    }

}

//  Events.Ev1.SuperNovaText();
//  supernova.SetActive(true);

// supernova.GetComponent<TextMeshProUGUI>().text = "The star swells to 100x it's size...\nthen slowly and gently releases it's gasses...\nrevealing bits of dust!\nA new discovery!";
//  supernova.GetComponent<Animation>().Play("EventAnim3");