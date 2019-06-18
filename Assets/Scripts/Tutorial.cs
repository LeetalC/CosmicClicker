using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tutorial : MonoBehaviour
{
    public GameObject tutorialPanel;
    public GameObject startingText;
    public GameObject theButton;

    public string currStory = ">> ...\n\n\n";
    public string[] storyTextArr = {">> What's this?\n",">> is it...existence?\n\n", ">> you feel... a primal urge\n\n\n",
        ">> overwhelming you.\n\n\n\n\n", ">> an instinct so primitive to you:\n\n\n", ">> fabricate this universe.\n\n\n\n\n", ">>Tap anywhere to continue." };
    public static int counter = 0;
    private void Update()
    {
        if (Input.GetKeyDown("s"))
        {
            fadeSceneIn();
            this.enabled = false;
        }
  
    }
    private void Start()
    {
        Debug.Log("startinh...");
        startingText.GetComponent<TextMeshProUGUI>().text = currStory;
    }
    public void nextWords() {
        Debug.Log(" counter is:  " + counter);
        if (counter >= storyTextArr.Length -1)
        {
            fadeSceneIn();
        }
        else
        {
            counter++;
            currStory = string.Concat(currStory,storyTextArr[counter]);
            startingText.GetComponent<TextMeshProUGUI>().text = currStory;

        }
    }


    public void fadeSceneIn()
    {

        Destroy(startingText);
        Destroy(theButton);
        tutorialPanel.GetComponent<Animation>().Play("GeneralFadeAnim");
        //Image img = tutorialPanel.GetComponent<Image>();
        //var col = img.color;
        //col.a = 0f;
        //img.color = col;


    }
}



// Start is called before the first frame update
//void Start()
//{
//    panelImg = tutorialPanel.GetComponent<Image>();
//    targetAlpha = panelImg.color.a;
//    Debug.Log(targetAlpha);
//    Update();

//}

//// Update is called once per frame
//void Update()
//{
//    Debug.Log("the target alpha is...: " + targetAlpha);

//    Color curColor = panelImg.color;

//    Debug.Log("currcolor is: " + curColor);
//    float alphaDiff = Mathf.Abs(curColor.a - targetAlpha);
//    Debug.Log(alphaDiff);
//    if (alphaDiff > 0.0001f)
//    {
//        curColor.a = Mathf.Lerp(curColor.a, targetAlpha, FadeRate * Time.deltaTime);
//        panelImg.color = curColor;
//    }

//}
