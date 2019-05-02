using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StarTimer : MonoBehaviour {
    
    public float lifeTime = 0;
    public float longLifeSpan = 25;
    public float shortLifeSpan = 10;

    public GameObject theStar;
    public GameObject timerText;
    public GameObject supernovaText;

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
        if (theStar.tag == "BlueStar") lifeTime = shortLifeSpan;
        else lifeTime = longLifeSpan;

        timerText.SetActive(true);
        Update();
    }

    // Update is called once per frame
    void Update() {   
        lifeTime -= 1 * Time.deltaTime;
        timerText.GetComponent<TextMeshProUGUI>().text = lifeTime.ToString("F2");

        if (lifeTime <= 0) TurnOff();
    }
  
    public void TurnOff() {
        timerText.SetActive(false);
        supernovaText.SetActive(true);
        supernovaText.GetComponent<TextMeshProUGUI>().text = "+" + StarFunctions.dustGained;
        supernovaText.GetComponent<Animation>().Play("FadeOut");

        //RandomAsteroid.generateAsteroidImage();
        this.enabled = false;
      
    }
}
/*The star swells to 100x it's size...
then slowly and gently releases it's gasses...
revealing bits of dust!
A new discovery!*/
