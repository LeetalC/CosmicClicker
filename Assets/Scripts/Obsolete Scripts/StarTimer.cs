using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StarTimer : MonoBehaviour {
    
    public float lifeTime = 0;  //this value gets set and changes over time
    public static float intLifeTime;    //this value is fixed
    public GameObject timerText;    //the timer attached to a star
    public GameObject supernovaText;    //the amount you recieved from a supernova


    public float GetlifeTime() {
        return lifeTime;
    }
    public void SetLifeTime(float value) {
        lifeTime += value;
    }
    // Start is called before the first frame update
    public void Start()
    {
        supernovaText.SetActive(false);
        timerText.SetActive(true);
        lifeTime = intLifeTime;
        Update();
    }

    // Update is called once per frame
    void Update() {   
        lifeTime -= 1 * Time.deltaTime;
        timerText.GetComponent<TextMeshProUGUI>().text = lifeTime.ToString("F2");
        if (lifeTime <= 0 && StarFunctions.superNovaHappened) TurnOff();
    }
  
    public void TurnOff() {
        timerText.SetActive(false);
        this.enabled = false;
      
    }
}
//old code when i had the star blow up and auto give you dust
     //   supernovaText.SetActive(true);
     //   supernovaText.GetComponent<TextMeshProUGUI>().text = "+" + StarFunctions.dustGained;
     //   supernovaText.GetComponent<Animation>().Play("FadeOut");
/*The star swells to 100x it's size...
then slowly and gently releases it's gasses...
revealing bits of dust!
A new discovery!*/
