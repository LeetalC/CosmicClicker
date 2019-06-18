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

    public static int dustGained;   //accessed in startimer to tell us how much a supernova gives
    //public void Awake() {
    //    Update();
    //}
    public static int getDustGained() {
        return dustGained;
    }

   // public GameObject supernova;
    public static bool superNovaHappened = false;

    private void Update() {
        if (mytimer.GetlifeTime() <= 0) {
            SupernovaEvent();
            superNovaHappened = true;
        }
    }
    //called once getlifetime returns <=0
    public void SupernovaEvent() {
        starButton.SetActive(false);
        MakeStar.currStarCount--;

        if (!timesped) intdustGained = Random.Range(1,5);
        else {
            if (starButton.tag == "BlueStar") intdustGained = Random.Range(100, 1000);
      
            else intdustGained = Random.Range(10, 20);
        }
        Debug.Log("A Star has exploded, awarding you with " + intdustGained + " dust.");
        timesped = false;
        CurrencyCollected.Instance.intDust += intdustGained;
        //BUG: THE AMOUNT OF DUST PHYSICALLY GAINED CONFLICTS 
        //WITH WHAT IS BEING DISPLAYED. SEEMS TO ONLY HAPPEN WITH !TIMESPED
        dustGained = intdustGained;
        supernovaSound.playSuperNovaSound();
        superNovaHappened = true;
        RandomAsteroid.generateAsteroids();
        TurnOff();
    }
    //this is called on button click on the redstarbutton prefab
    public void SpeedTime() {
        mytimer.SetLifeTime(-1);
        timesped = true;
    }
    //disables the script, called at end of SuperNovaevent()
    public void TurnOff() {
        this.enabled = false;
    }

}

//  Events.Ev1.SuperNovaText();
//  supernova.SetActive(true);

// supernova.GetComponent<TextMeshProUGUI>().text = "The star swells to 100x it's size...\nthen slowly and gently releases it's gasses...\nrevealing bits of dust!\nA new discovery!";
//  supernova.GetComponent<Animation>().Play("EventAnim3");