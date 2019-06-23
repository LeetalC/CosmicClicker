
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MakeStar : MonoBehaviour
{
    
    public float longLifeTime = 25f;
    public float shortLifeTime = 10f;
    //for the star obj
    public GameObject starMadeEvent;

    public Sounds makeStarButtonSound;

    public static bool madeBlueStar = false;
    public static bool madeRedStar = false;


    public static Transform transformStar;
    public static int maxNumStars = 15;
    public static int currStarCount = 0;


    private Transform starButtonChild;
    private Transform timerChild;
    private Transform asteroidChild;
    public GameObject starPrefab;

   // public GameObject timerChild;
 //   public GameObject asteroidChild;
    public Sprite blueStarImg;
    public Sprite redStarImg;
    public static Vector3 starsPosition;    //going to use this var to generate asteroids or dust in the area 

    private int minX = 150;
    private int minY = 600;
    private int newX = 1080;
    private int newY = 1920;
    public void Update()
    {
        if (Input.GetKeyDown("2"))
        {
            MakeAStar();
        }
    }

    public Transform makeStar(Sprite img, int gasCost, string color, float life, ref bool madeStar){
        Transform aStar;
        starsPosition = new Vector3(Random.Range(minX, newX-minX), Random.Range(minY, newY-400), 0);

        //BUG: instantiating blue stars will get a red star image for some reason
        //the first star always has a problem
        aStar = Instantiate(starPrefab, starsPosition, Quaternion.identity).transform;
       // aStar = Instantiate(starButtonChild, starsPosition, Quaternion.identity).transform; //previous
     //   starButtonChild = aStar.transform.GetChild(0);
        aStar.GetComponentInChildren<Image>().sprite = img;
        //starButtonChild.GetComponent<SpriteRenderer>().sprite = img;
        //starButtonChild.GetComponent<Button>().image.sprite = img;

       // starButtonChild.GetComponent<Image>().sprite = img;


        CurrencyCollected.Instance.intGas -= gasCost;
        AllStarFunctions.intLifeTime = life;

        Debug.Log("STARS INFORMATION: Star Color: " + color + ", Star image used: " +
        img + ", Star Life: " + AllStarFunctions.intLifeTime + ", Gas Cost Reduc: " + 
        gasCost + "Star's Position: " + starsPosition.ToString("F2"));

        madeStar = true;
        return aStar;
    }
    

    public void MakeAStar() {   
        Transform aStar;
        
        if (currStarCount < maxNumStars) {  //asking if we are allowed to make another star
            makeStarButtonSound.succeedFail(true);

             //makes a blue star if you have the gas count for it 
            if (CurrencyCollected.Instance.intGas >= 100 && Upgrader.bluestarunlocked) {   
                aStar = makeStar(blueStarImg, 100, "Blue", shortLifeTime,  ref madeBlueStar);
            }
            else {  //makes a red star instead
                aStar = makeStar(redStarImg, 30,"Red", longLifeTime, ref madeRedStar);
            }

            //making the object a child of the starspanel
            aStar.SetParent(GameObject.FindGameObjectWithTag("StarsPanel").transform, true);


            starMadeEvent.GetComponent<Animation>().Stop("EventAnim");
            starMadeEvent.GetComponent<TextMeshProUGUI>().text = "A star has been born " + starsPosition.ToString("F2");
            starMadeEvent.GetComponent<Animation>().Play("EventAnim");

            transformStar = aStar;
            currStarCount++;

           //fixed from hardcode
           madeBlueStar = madeRedStar = false;
           Destroy(aStar.gameObject, AllStarFunctions.intLifeTime + 10f);    
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