using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Settings : MonoBehaviour
{
    public GameObject bgMusicObj;
    public Sounds soundController;
   
    public void changeMusic() {
        string name = EventSystem.current.currentSelectedGameObject.name;
        AudioSource audio = bgMusicObj.GetComponent<AudioSource>();

        if (name == "BGM1")
            audio.clip = soundController.setBGMusic(0);
        if (name == "BGM2")
        {
            audio.clip = soundController.setBGMusic(1);
            audio.volume = .5f;
        }
        if (name == "BGM3")
        {
            audio.clip = soundController.setBGMusic(2);
            audio.volume = .5f;
        }


        audio.Play();
    }
}
