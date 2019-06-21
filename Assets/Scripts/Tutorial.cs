using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//this script has so many bugs.
public class Tutorial : MonoBehaviour
{
    //these buttons will gradually be revealed as the tutorial progresses
    public GameObject gasButton;
    public GameObject starButton;
    public GameObject menuButton;
    public GameObject settingsButton;


    public GameObject tutorialPanel;    //the panel that holds all tutorial objects
    public GameObject startingText; //initial story text, is destroyed upon finishing
    public GameObject theButton;    //the continue button, which allows the user to click anywhere to continue;

    public GameObject harvestGasTutorialText;   //the text box that hold the tutorial to make gas
    public GameObject makeStarTutorialText;     //the text box that holds the tutorial to make a star

    public bool storyWasTold = false;
    public bool gasTutDone = false;

    //vars to help tell initial story
    public string currStory = ">> ...\n\n\n";
    public string[] storyTextArr = {">> What's this?\n",">> is it...existence?\n\n", ">> you feel... a primal urge\n\n\n",
        ">> overwhelming you.\n\n\n\n\n", ">> an instinct so primitive to you:\n\n\n", ">> fabricate this universe.\n\n\n\n\n", ">>Tap anywhere to continue." };

    //phrases depending on where the user is in the tutorial
    public string currTutStory = "";
    public string[,] tutorialTextArr = { 
        { "Everything is made from Hydrogen and Helium.", "Tap here to collect some." }, 
        { "You've collected enough gas to create a star!", "Tap here to make one." }, 
        { "This star doesn't seem very hot, But it burns true for a long time.",  "What happens when it dies? Try speeding up time by tapping." }
    };

    public static int counter = 0;
    public static int k = 0;
    public static int j = 0;
    public static int storyLine = 0;

    private void Update()
    {
        if (Input.GetKeyDown("s"))
        {
            fadeSceneIn();
            this.enabled = false;
        }
        if (Input.GetKeyDown("f"))
        {
            fadeSceneIn();
            Destroy(theButton);
            Destroy(tutorialPanel);
            menuButton.SetActive(true);
            gasButton.SetActive(true);
            settingsButton.SetActive(true);
            starButton.SetActive(true);
            this.enabled = false;
        }
  
    }

    //the begining of time bitch
    private void Start()
    {
        startingText.GetComponent<TextMeshProUGUI>().text = currStory;
    }

    //every single click calls this function
    public void nextWords() {
        Debug.Log("nextWords was called");
        if (storyWasTold)
        {
            Debug.Log("story was told...");
            //logically this makes no fucking sense. if the tutorial is not done, then continue???? why please ask harout
            if (!gasTutDone)
            {
                Debug.Log("Gas tut is done calling make star");
                Destroy(harvestGasTutorialText);
                makeStarTut();
               
            }
            else
            {
                Debug.Log("Gas tut not done..");
                harvestGasTut();
            }

        }
        else
        {
            if (counter >= storyTextArr.Length - 1)
            {
                fadeSceneIn();
            }
            else
            {
                counter++;
                currStory = string.Concat(currStory, storyTextArr[counter]);
                startingText.GetComponent<TextMeshProUGUI>().text = currStory;

            }
        }
    }
 
    public void fadeSceneIn()
    {
        //deactivating all starting buttons
        menuButton.SetActive(false);
        gasButton.SetActive(false);
        settingsButton.SetActive(false);
        starButton.SetActive(false);

        Debug.Log("Fade scene in activated.");
        Destroy(startingText);
       // Destroy(theButton);
        tutorialPanel.GetComponent<Animation>().Play("GeneralFadeAnim");



        storyWasTold = true;
        nextWords();

        //old code to just snap the panels alpha to 0

        //Image img = tutorialPanel.GetComponent<Image>();
        //var col = img.color;
        //col.a = 0f;
        //img.color = col;


    }
    
    public void harvestGasTut()
    {
        //this is completely bugged out
        Debug.Log("you're in harvest gas tutorial.\nthe value of j is: " + j);
        if (j == 1)
        {
            harvestGasTutorialText.GetComponent<TextMeshProUGUI>().alignment = TextAlignmentOptions.Top;
            harvestGasTutorialText.GetComponent<TextMeshProUGUI>().text = "Everything is made from Hydrogen and Helium.";
            j++;
        }

        else
        {
            Debug.Log("WHY ARE WE HERE........");
            harvestGasTutorialText.GetComponent<TextMeshProUGUI>().alignment = TextAlignmentOptions.Bottom;
            harvestGasTutorialText.GetComponent<TextMeshProUGUI>().text = "Tap here to collect some.";
            gasButton.SetActive(true);
            Image img = theButton.GetComponent<Image>();
            img.rectTransform.position = new Vector2(0, 1000);
            img.rectTransform.sizeDelta = new Vector2(1090, 1620);
        }
        if (CurrencyCollected.Instance.intGas > 0)
        {
           
            j = 0;
            k++;
            gasTutDone = true;
        }
    }

    public void makeStarTut()
    {
        
        if (j < tutorialTextArr.Length)
        {
            currTutStory = tutorialTextArr[k, j];
            makeStarTutorialText.GetComponent<TextMeshProUGUI>().text = currTutStory;
            j++;
        }
        else
        {
            starButton.SetActive(true);
            j = 0;
            k++;
            starButton.SetActive(true);
            Destroy(makeStarTutorialText);
            getDustTut();
        }
    }

    public void getDustTut() {
    }


}


//}



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
