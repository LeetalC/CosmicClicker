using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    //public AudioSource[] clips;
    public AudioClip[] beeps;
    public AudioClip[] novas;
    public AudioClip[] succeedORFail;
    public AudioSource soundMaker;

    public void Awake() {
        soundMaker = GetComponent<AudioSource>();
    }
    public int getRand(int l) {
        return Random.Range(0, l);
    }
    public void playSound() {
        soundMaker.clip = beeps[getRand(beeps.Length)];
        soundMaker.Play();
    }

    public void playSuperNovaSound() {
        soundMaker.clip = novas[getRand(novas.Length)];
        soundMaker.Play();

    }

    public void succeedFail(bool b) {
        if (b) soundMaker.clip = succeedORFail[1];
        else soundMaker.clip = succeedORFail[0];
        soundMaker.Play();
    }

}
