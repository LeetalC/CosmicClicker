using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour {
    public static Singleton instance;
    void Awake() {
        if (instance != null) {
            Destroy(gameObject);
        }
        else {
            instance = this;
            //DontDestroyOnLoad(gameObject);
            DontDestroyChildOnLoad(gameObject);
        }
    }
    public void DontDestroyChildOnLoad(GameObject child) {
        Transform parentTransform = child.transform;
        while (parentTransform.parent != null && parentTransform.name !="Canvas") {
            parentTransform = parentTransform.parent;
        }
        GameObject.DontDestroyOnLoad(parentTransform.gameObject);
    }

}
