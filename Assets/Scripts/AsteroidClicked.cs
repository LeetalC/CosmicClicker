using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//new Script
public class AsteroidClicked : MonoBehaviour
{
    //how much each asteroid will give you
    private int tiny = 2;
    private int small = 4;
    private int medium = 10;
    private int cluster = 15;
    private int large = 25;
    private int num = 0;

    //brute force timer for removing asteroids after click
    private float timer = .45f;
    public GameObject callingObj;   //the asteroid button prefab
    public GameObject dustGainedText;

        //is called when asteroid button is clicked.
       public void clicked() {
        string name = callingObj.GetComponent<Image>().sprite.name;

        if(name == "Tiny_Asteroid_Sprite") {
            CurrencyCollected.Instance.intDust+=tiny;
            num = tiny;
        }
        else if(name == "Small_Asteroid_Sprite") {
            CurrencyCollected.Instance.intDust+=small;
            num = small;
        }
        else if (name == "Medium_Asteroid_Sprite") {
            CurrencyCollected.Instance.intDust+=medium;
            num= medium;
        }
        else if(name == "Asteroid_Cluster_Sprite") {
            CurrencyCollected.Instance.intDust+=cluster;
            num = cluster;
        }
        else {
            CurrencyCollected.Instance.intDust+=large;
            num = large;
        }
        
        dustGainedText.GetComponent<TextMeshProUGUI>().text = "+" + num;
        dustGainedText.GetComponent<Animation>().Play("FadeOut");
    
    //hiding the button momentarily before it gets destroyed. 
    //opacity is set to 0, and button isn't interactable
        callingObj.GetComponent<Button>().interactable = false;
        Image img = GetComponent<Image>();
        var temp = img.color;
        temp.a = 0f;
        img.color = temp;

       Destroy(callingObj, timer);
        
    }

        Quaternion PointOnCircle2D(float p, int steps)
    {
        float degrees = 360f / steps;
        return Quaternion.Euler(0f, 0f, p * -degrees);
    }
}
