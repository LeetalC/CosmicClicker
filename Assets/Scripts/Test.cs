using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Test : MonoBehaviour
{
    public CurrencyCollected cc;
    void Awake(){
        cc = CurrencyCollected.Instance;
    }

    public GameObject asteroidButton;
    [Range(0, 360)]
    public float rot;
    public bool randomRot;
    void OnDrawGizmos()
    {
        if (randomRot)
        {
 
            Quaternion temp = PointOnCircle2D(rot, 280);
            asteroidButton.GetComponent<Transform>().localRotation = temp;
 
        }
    }
    Quaternion PointOnCircle2D(float p, int steps)
    {
        float degrees = 360f / steps;
        return Quaternion.Euler(0f, 0f, p * -degrees);
    }
}