﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MakeStar : MonoBehaviour
{
    
    //for the star obj
    public GameObject starMadeEvent;
    public GameObject[] stars;
    public GameObject redStar;
    public GameObject blueStar;
    public Sounds makeStarButtonSound;

    public bool madeBlueStar = false;
    public bool madeRedStar = false;

    public static Transform transformStar;
    public static int maxNumStars = 1;
    public static int currStarCount = 0;
    public GameObject img1;
    public GameObject img2;


    public void Start() {
        
    }
    //public void instantiateStarbirthimg(Vector3 pos) {
    //    Instantiate(img1, pos, Quaternion.identity);
       
    //}

    public void MakeAStar() {   
        Transform aStar;
        int newX = 1080;
        int newY = 1920;


        if (currStarCount < maxNumStars) {  //asking if we are allowed to make another star

            makeStarButtonSound.succeedFail(true);
            Vector3 position = new Vector3(Random.Range(100, newX-100), Random.Range(700, newY-400), 0);
          //  instantiateStarbirthimg(position);
            // posArr[i] = position; possibly might go back to the idea of an array of positions
            if (CurrencyCollected.Instance.intGas >= 500 && Upgrader.bluestarunlocked == true) {    //makes a blue star if you have the gas count for it  
                aStar = Instantiate(blueStar, position, Quaternion.identity).transform;
                CurrencyCollected.Instance.intGas -= 500;
                Debug.Log("You made a blue star, your gas count has been reduced by 100.");
                madeBlueStar = true;
                
            }
            else {  //makes a red star instead
                aStar = Instantiate(redStar, position, Quaternion.identity).transform;
                CurrencyCollected.Instance.intGas -= 20;
                Debug.Log("You made a red star, your gas count has been reduced by 20.");
                madeRedStar = true;
            }

            aStar.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

            starMadeEvent.GetComponent<Animation>().Stop("EventAnim");

            starMadeEvent.GetComponent<TextMeshProUGUI>().text = "A star has been born " + position.ToString("F2");
            starMadeEvent.GetComponent<Animation>().Play("EventAnim");

            transformStar = aStar;
            currStarCount++;
            madeRedStar = madeBlueStar = false;
            
        }
        else {
            makeStarButtonSound.succeedFail(false);
            starMadeEvent.GetComponent<TextMeshProUGUI>().text = "You are only allowed " + maxNumStars + " star(s)!!";
            starMadeEvent.GetComponent<Animation>().Play("EventAnim");
        }
    }  
}












//ALL THE POSITIONS THAT HAVE FAILED ME!!!!!!!!!!

//float posX = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);
//float posY = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
//Vector3 position = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), Camera.main.farClipPlane / 2));
// Debug.Log("HERE IS A THING: " + Camera.main.ScreenToViewportPoint(position));
// Debug.Log("Screen width is: " + Screen.width + " and Screen height is " + Screen.height);
// Vector3 position = new Vector3(Random.Range(Screen.width / 2, Screen.width), Random.Range(Screen.height / 2, Screen.height), 0);
//Vector3 position = new Vector3(Screen.width, Screen.height, 0);
//Vector3 middle = new Vector3(0, 50, 0);
// Vector3 tempPos = new Vector3(3, 3, 0);
//Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360)))


//if (k < 10) {

//    aStar.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);

//    k++;
//}
//else {
//    Debug.Log("No more stars can be placed on the screen.");
//}

//Instantiate(stars[k], new Vector3(Random.Range(Screen.width / 2, Screen.width), Random.Range(Screen.height / 2, Screen.height), 0), Quaternion.identity);
//Instantiate(stars[k],position, Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360))));
//Instantiate(star, position, Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360))));
//
//stars[k].transform.SetParent(newParent, false);
//  stars[k].transform.parent = canvas;