using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Upgrader : MonoBehaviour {

    public GameObject upgradeText;
    public GameObject eventText;

    public GameObject harvestorCostText;
    public GameObject starcapCostText;
    public GameObject passiveGenText;

    public Button harvesterUp;
    public Button starCapUp;
    public Button getBlueStarsUp;
    public Button passiveGasGenUp;
    
    public int dustUpgradeMax = 2;
    public int harvesterUpgradeMax = 100;

    //should probably make these private
    public int bsGASCOST = 1000;
    public int bsDUSTCOST = 10;

    public int pggGASCOST = 100;
    public int pggDUSTCOST = 2;

    public int iscGASCOST = 200;
    public int iscDUSTCOST = 5;

    public int uhGASCOST = 0;
    public int uhDUSTCOST = 2;

    public static bool bluestarunlocked = false;

    public bool eventTextError(int dust, int gas, int dustCost, int gasCost) {
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
        if(gas < gasCost) {
            eventText.GetComponent<TextMeshProUGUI>().text = ("Not enough gas! You need: " + (gasCost - gas) + " more gas.");
            eventText.GetComponent<Animation>().Play("EventAnim");
            return true;
        }

        return false;
    }
    public void Awake() {
      //  DontDestroyOnLoad(this);
    }
    public void Update() {
        harvestorCostText.GetComponent<TextMeshProUGUI>().text = (uhGASCOST + " Gas, " + uhDUSTCOST + " Dust.");
        starcapCostText.GetComponent<TextMeshProUGUI>().text = (iscGASCOST + " Gas, " + iscDUSTCOST + " Dust.");
        passiveGenText.GetComponent<TextMeshProUGUI>().text = (pggGASCOST + " Gas, " + pggDUSTCOST + " Dust.");
    }
    
    //things to update: a function that checks errors for you.
    
    public void UpgradeHarvestPerClick() {
     bool error = eventTextError(CurrencyCollected.dustCount, CurrencyCollected.gasCount, uhDUSTCOST,uhGASCOST);
        if (error == false) {
            upgradeText.GetComponent<Animation>().Stop("UpgradeAnim");
            upgradeText.GetComponent<TextMeshProUGUI>().text = ("+" + 2);
            GetGas.gasPerClick += 2;
            upgradeText.GetComponent<Animation>().Play("UpgradeAnim");
            CurrencyCollected.dustCount -= 2;
            uhDUSTCOST++;
        }
    }

    public void IncStarCapacity() {
        bool error = eventTextError(CurrencyCollected.dustCount, CurrencyCollected.gasCount, iscDUSTCOST, iscGASCOST);
        if (error == false) {
            MakeStar.maxNumStars += 1;
            CurrencyCollected.gasCount -= iscGASCOST;
            CurrencyCollected.dustCount -= iscDUSTCOST;
            iscGASCOST += 10;
            iscDUSTCOST++;
        }

    }

    public void PassiveGasGenerator() {
        bool error = eventTextError(CurrencyCollected.dustCount, CurrencyCollected.gasCount, pggDUSTCOST, pggGASCOST);
        if (error == false) {
            Events.passGasGen += 2;
            CurrencyCollected.gasCount -= pggGASCOST;
            CurrencyCollected.dustCount -= pggDUSTCOST;
            pggGASCOST += 100;
            pggDUSTCOST *= 2;
        }
    }

    //public static void UnlockBlueStars() {
    //    bluestarunlocked = true;
    //    CurrencyCollected.gasCount -= bsGASCOST;
    //    CurrencyCollected.dustCount -= bsDUSTCOST;
    //}


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
