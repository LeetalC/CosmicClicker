using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    //public AudioSource[] clips;
    public AudioClip[] beeps;
    public AudioClip[] novas;
    public AudioClip[] soundSucceeded;
    public AudioSource soundMaker;

    public void Awake() {
        soundMaker = GetComponent<AudioSource>();
    }
    //should be in another script of random helper functions?
    public int getRand(int l) {
        return Random.Range(0, l);
    }
    public void playSound() {
        soundMaker.clip = beeps[getRand(beeps.Length)];
        soundMaker.Play();
    }
    //is only called in starfunctions.cs when supernovaevent() happens
    public void playSuperNovaSound() {
        soundMaker.clip = novas[getRand(novas.Length)];
        soundMaker.Play();

    }
    //specifically when make a star fails because you have reached star cap
    public void succeedFail(bool b) {
        if (b) soundMaker.clip = soundSucceeded[1];
        else soundMaker.clip = soundSucceeded[0];
        soundMaker.Play();
    }

}
