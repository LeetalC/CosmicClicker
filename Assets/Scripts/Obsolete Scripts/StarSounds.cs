using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSounds : MonoBehaviour
{
    public AudioSource soundMaker;
    public AudioClip[] taps;
    public AudioClip[] novas;

    
    // Start is called before the first frame update
    void Start()
    {
        soundMaker = GetComponent<AudioSource>();
    }
    
     public int getRand(int l) {
        return Random.Range(0, l);
    }


    // Update is called once per frame
   public void playSound() {
        soundMaker.clip = taps[getRand(taps.Length)];
        soundMaker.volume = .09f;
        soundMaker.Play();
    }
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
