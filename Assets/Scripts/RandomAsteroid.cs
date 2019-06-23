using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomAsteroid : MonoBehaviour {
    private MakeStar ms;    //going to get stars position so these can generate asteroids
    public Sprite[] asteroidImages;

    public GameObject asteroidButton;

    public Vector3 pos;
    private int min;
    private int max;
    private int blueMinAsteroid = 5;
    private int blueMaxAsteroid = 10;
    private int redMinAsteroid = 1;
    private int redMaxAsteroid = 3;

    private float asteroidScreenTime = 5f;
    void Start(){
        pos = MakeStar.starsPosition;
    }
    //instantiating a random number of asteroid objects, with a random asteroid image
    public void generateAsteroids() {
        Transform aRock;
        if(MakeStar.madeBlueStar) 
        {
            min = blueMinAsteroid;
            max = blueMaxAsteroid;
        }
        else {
            min = redMinAsteroid;
            max = redMaxAsteroid;
        }
        //should REALLY generate asteroids based on 
        //stars, like tiny ones more likely to come out of red stars and vice versa
        for(int i = 0; i < Random.Range(min,max); i++){
            //generating an asteroid at an offset to the star
            aRock = Instantiate(asteroidButton, pos + new Vector3(Random.Range(-200,200), Random.Range(-200,200), 0), Quaternion.identity).transform;
            asteroidButton.GetComponent<Image>().sprite = asteroidImages[Random.Range(0, asteroidImages.Length)];
            aRock.SetParent(GameObject.FindGameObjectWithTag("StarsPanel").transform, true);
            Destroy(aRock, asteroidScreenTime);
        }

    }


    Quaternion PointOnCircle2D(float p, int steps)
    {
        float degrees = 360f / steps;
        return Quaternion.Euler(0f, 0f, p * -degrees);
    }
          //    float rot = Random.Range(0,360);
         //   Debug.Log("THE RANDOM NUMBEER IS: " + rot);
           // Quaternion temp = PointOnCircle2D(rot, 280);
          //  RectTransform rt = asteroidButton.GetComponent<RectTransform>();
          //  rt.Rotate( new Vector3( 0, 0, Random.Range(0,360) ) );
           // asteroidButton.GetComponent<Transform>().rotation = temp;


            //Random.Range(0,360);

}