using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioSource[] clips;
    public void playSound() {
        int i = Random.Range(0, clips.Length);
        clips[i].Play();
    }

}
