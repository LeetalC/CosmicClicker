using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StarFunctions : MonoBehaviour
{
    public GameObject starButton;
    public StarTimer mytimer;
    //public Sounds supernovaSound;
    public int intdustGained = 0;
    public bool timesped = false;
    public Animator anim;
    public RandomAsteroid ra;
    public StarSounds supernovaSound;
    public static int dustGained;   //accessed in startimer to tell us how much a supernova gives
    //public void Awake() {
    //    Update();
    //}
    void Start(){
        anim = starButton.GetComponent<Animator>();
    }
    public static int getDustGained() {
        return dustGained;
    }

   // public GameObject supernova;
    public static bool superNovaHappened = false;

    private void Update() {
        
        
        if(Input.GetMouseButtonDown(0)) anim.SetBool("isTapped", true);
        else anim.SetBool("isTapped",false);

        if (mytimer.GetlifeTime() <= 0) {
            SupernovaEvent();
        }
    }
    //called once getlifetime from startimer returns <=0
    public void SupernovaEvent() {

        starButton.SetActive(false);
        MakeStar.currStarCount--;

        if (!timesped) intdustGained = Random.Range(1,3);
        else {
            if (MakeStar.madeBlueStar) intdustGained = Random.Range(20, 35);
      
            else intdustGained = Random.Range(4, 8);
        }
        Debug.Log("A Star has exploded, awarding you with " + intdustGained + " dust.");
        CurrencyCollected.Instance.intDust += intdustGained;
        dustGained = intdustGained;

        superNovaHappened = true;
        supernovaSound.playSuperNovaSound();
        ra.generateAsteroids();
        TurnOff();
    }
    //this is called on button click on the redstarbutton prefab
    public void SpeedTime() {
        mytimer.SetLifeTime(-.5f);;
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