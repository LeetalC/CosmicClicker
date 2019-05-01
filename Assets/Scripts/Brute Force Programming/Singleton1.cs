using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton1 : MonoBehaviour
{
    public static Singleton1 instance;
    void Awake() {
        if (instance != null) {
            Destroy(gameObject);
        }
        else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
