using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Upgrader : MonoBehaviour {
    // public GameObject upgradeText; used for anim should delete
    public GameObject eventText;

    //the display text for the cost of upgrades
    public GameObject harvestorCostText;
    public GameObject starcapCostText;
    public GameObject passiveGenText;
    public GameObject blueStarCostText;

    public GameObject gasPerClickDisplay;
    public GameObject numberofStarsDisplay;
    public GameObject passiveGasGenDisplay;

    //buttons correlated with upgrades
    public Button harvesterUp;
    public Button starCapUp;
    public Button getBlueStarsUp;
    public Button passiveGasGenUp;

    public GameObject harvesterTextLevel;
    public GameObject maxStarsTextLevel;
    public GameObject passiveGasTextLevel;


    public int dustUpgradeMax = 2;
    public int harvesterUpgradeMax = 100;

    //should probably make these private
    //cost of each upgrade
    public int bsGASCOST = 1000;
    public int bsDUSTCOST = 10;

    public int pggGASCOST = 100;
    public int pggDUSTCOST = 2;

    public int iscGASCOST = 200;
    public int iscDUSTCOST = 5;

    public int uhGASCOST = 0;
    public int uhDUSTCOST = 2;

    private int harvesterLevel = 0;
    private int maxStarLevel = 0;
    private int passiveGasLevel = 0;

    public static bool bluestarunlocked = false;

void Start(){
    UpdateInfo();
}
    public bool eventErrorFound(int dust, int gas, int dustCost, int gasCost) {
        if (gas < gasCost && dust < dustCost) {
            eventText.GetComponent<TextMeshProUGUI>().text = ("Not enough gas or dust! You need: " + (gasCost - gas) + " more gas and " + (dustCost - dust) + " more dust.");
            eventText.GetComponent<Animation>().Play("EventAnim");
            return true;
        }
        if (dust < dustCost) {
            eventText.GetComponent<TextMeshProUGUI>().text = ("Not enough dust! You need: " + (dustCost - dust) + " more dust.");
            eventText.GetComponent<Animation>().Play("EventAnim");
            return true;
        }
        if (gas < gasCost) {
            eventText.GetComponent<TextMeshProUGUI>().text = ("Not enough gas! You need: " + (gasCost - gas) + " more gas.");
            eventText.GetComponent<Animation>().Play("EventAnim");
            return true;
        }

        return false;
    }
    public void say(string s) {
        eventText.GetComponent<Animation>().Stop("EventAnim");
        eventText.GetComponent<TextMeshProUGUI>().text = (s);
        eventText.GetComponent<Animation>().Play("EventAnim");
    }
    public void displayLevel(GameObject obj, int level){
        obj.GetComponent<TextMeshProUGUI>().text = (level.ToString("#"));
    }
    public void Update() {
        //horribly inefficient find better solution to display the text.

      
    }

    void UpdateInfo(){
  gasPerClickDisplay.GetComponent<TextMeshProUGUI>().text = (GetGas.gasPerClick + " /tap");
        numberofStarsDisplay.GetComponent<TextMeshProUGUI>().text = (MakeStar.maxNumStars + " stars");
        passiveGasGenDisplay.GetComponent<TextMeshProUGUI>().text = (Events.passGasGen +" /" + Events.seconds + " sec");
        displayLevel(harvesterTextLevel,harvesterLevel);
        displayLevel(maxStarsTextLevel,maxStarLevel);
        displayLevel(passiveGasTextLevel,passiveGasLevel);



        harvestorCostText.GetComponent<TextMeshProUGUI>().text = (uhGASCOST + " Gas, " + uhDUSTCOST + " Dust.");
        starcapCostText.GetComponent<TextMeshProUGUI>().text = (iscGASCOST + " Gas, " + iscDUSTCOST + " Dust.");
        passiveGenText.GetComponent<TextMeshProUGUI>().text = (pggGASCOST + " Gas, " + pggDUSTCOST + " Dust.");
        if (!bluestarunlocked) blueStarCostText.GetComponent<TextMeshProUGUI>().text = (bsGASCOST + " Gas, " + bsDUSTCOST + " Dust.");
    }
    //---------------------------
    //each function happens on click to their respective upgrade object in the menu panel
    //the if statement is checking for errors and the body runs only when no errors are found
    //TODO: have a small animation and space for each button to display how much is being updated
    public void UpgradeHarvestPerClick() {
        if (!eventErrorFound(CurrencyCollected.Instance.intDust, CurrencyCollected.Instance.intGas, uhDUSTCOST, uhGASCOST)) {
            //upgradeText.GetComponent<Animation>().Stop("UpgradeAnim");
            // upgradeText.GetComponent<TextMeshProUGUI>().text = ("+" + 2);
            GetGas.gasPerClick += 2;
            say("Upgraded Harvester.");
            harvesterLevel++;
            // upgradeText.GetComponent<Animation>().Play("UpgradeAnim");
            CurrencyCollected.Instance.intDust -= uhDUSTCOST;
            uhDUSTCOST++;
        }
        UpdateInfo();
    }

    public void IncStarCapacity() {
        if (!eventErrorFound(CurrencyCollected.Instance.intDust, CurrencyCollected.Instance.intGas, iscDUSTCOST, iscGASCOST)) {
            say("Star Cap Increased.");
            maxStarLevel++;
            MakeStar.maxNumStars += 1;
            CurrencyCollected.Instance.intGas -= iscGASCOST;
            CurrencyCollected.Instance.intDust -= iscDUSTCOST;
            iscGASCOST += 10;
            iscDUSTCOST++;
        }
        
        UpdateInfo();

    }

    public void PassiveGasGenerator() {
        if (!eventErrorFound(CurrencyCollected.Instance.intDust, CurrencyCollected.Instance.intGas, pggDUSTCOST, pggGASCOST)) {
            say("Passive Gas Increased.");
            passiveGasLevel++;
            Events.passGasGen += 2;
            CurrencyCollected.Instance.intGas -= pggGASCOST;
            CurrencyCollected.Instance.intDust -= pggDUSTCOST;
            pggGASCOST += 100;
            pggDUSTCOST *= 2;
        }
        
        UpdateInfo();
    }

    public void UnlockBlueStars() {
        if (!eventErrorFound(CurrencyCollected.Instance.intDust, CurrencyCollected.Instance.intGas, bsDUSTCOST, bsGASCOST)) {
            say("Unlocked Blue Stars.");
            bluestarunlocked = true;
            CurrencyCollected.Instance.intGas -= bsGASCOST;
            CurrencyCollected.Instance.intDust -= bsDUSTCOST;
            Destroy(getBlueStarsUp.gameObject);
            Destroy(blueStarCostText.gameObject);
        }
        
        UpdateInfo();
    }
    //--------------------------------------------
}


/*   //harvesterUp.interactable = true;
        //starCapUp.interactable = true;
        //passiveGasGenUp.interactable = true;
        //toggles interactivness. Can't use both this, and the system that controls the cool event text
        //if (CurrencyCollected.dustCount < 2) {
        //    harvesterUp.interactable = false;
           
        //}
        //else {
        //    harvesterUp.interactable = true;
        //}

        //if (CurrencyCollected.gasCount < 200 || CurrencyCollected.dustCount < 5) {
        //    starCapUp.interactable = false;
        //}
        //else {
        //    starCapUp.interactable = true;
        //}
        //if (CurrencyCollected.gasCount < 100 || CurrencyCollected.dustCount < 2) {
        //    passiveGasGenUp.interactable = false;
        //}
        //else {
        //    passiveGasGenUp.interactable = true;
        //}*/
