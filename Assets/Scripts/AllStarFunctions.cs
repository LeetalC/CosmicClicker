using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//this class attempts to combine three scripts
public class AllStarFunctions : MonoBehaviour
{
    //StarTimer
    public float lifeTime = 0;  //this value gets set and changes over time
    public static float intLifeTime;    //this value is fixed
    public int intdustGained = 0;
    public bool timesped = false;
    public static bool superNovaHappened = false;

    
    public GameObject timerText;    //the timer attached to a star
    public GameObject starButton;
    public Animator anim;
    public RandomAsteroid ra;
    
    //StarSounds
    public AudioSource soundMaker;
    public AudioClip[] taps;
    public AudioClip[] novas;



    void Start()
    {

        timerText.SetActive(true);
        lifeTime = intLifeTime;
        soundMaker = GetComponent<AudioSource>();
        anim = starButton.GetComponent<Animator>();
    }
    void Update() {   
        lifeTime -= 1 * Time.deltaTime;
        timerText.GetComponent<TextMeshProUGUI>().text = lifeTime.ToString("F2");
       // if (lifeTime <= 0 && superNovaHappened) TurnOff();

        if(Input.GetMouseButtonDown(0)) anim.SetBool("isTapped", true);
        else anim.SetBool("isTapped",false);

        if (GetlifeTime() <= 0) {
            SupernovaEvent();
        }
    }

    //STAR TIMER
    public void SetLifeTime(float value) {
        lifeTime += value;
    }

    public float GetlifeTime() {
        return lifeTime;
    }
        public void TurnOff() {
        timerText.SetActive(false);
        this.enabled = false;
      
    }

    public void SpeedTime() {
        SetLifeTime(-.5f);;
        timesped = true;
    }
     
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

        superNovaHappened = true;
        playSuperNovaSound();
        ra.generateAsteroids();
        TurnOff();
    }

    public int getRand(int l) {
        return Random.Range(0, l);
    }
    //This is called by the star button child, when it detects a click
   public void playSound() {
        soundMaker.clip = taps[getRand(taps.Length)];
        soundMaker.volume = .09f;
        soundMaker.Play();
    }
    //this is called in the supernovaevent function
    public void playSuperNovaSound() {
        Debug.Log("in super nova sound...");
        int i = getRand(novas.Length);
        soundMaker.clip = novas[i];
        if(i== 0)
        {
            soundMaker.volume = .08f;
        }
        soundMaker.Play();

    }
}
