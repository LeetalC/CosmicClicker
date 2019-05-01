using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SingletonOK<T> : MonoBehaviour where T : MonoBehaviour {
    private static T s_instance;

    public static T Instance {
        get {
            if (s_instance == null) {
                s_instance = GameObject.FindObjectOfType<T>();

                if (FindObjectsOfType(typeof(T)).Length > 1) {
                    Debug.LogError("[Singleton] Something went really wrong " +
                                    " - there should never be more than 1 singleton!" +
                                    " Reopening the scene might fix it.");
                    return s_instance;
                }

                if (s_instance == null) {
                    GameObject singleton = new GameObject();
                    s_instance = singleton.AddComponent<T>();
                    singleton.name = "(Singleton) " + typeof(T).ToString();

                    DontDestroyOnLoad(singleton);

                    Debug.Log("[Singleton] An instance of " + typeof(T) +
                        " is needed in the scene, so '" + singleton +
                        " was created with DontDestroyOnLoad.");
                }
            }
            return s_instance;
        }
    }
}




//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class SingletonOK<T> : MonoBehaviour where T : MonoBehaviour
//{
//    private static T s_instance;
//    public static T Instance {
//        get {
//            if (s_instance == null) {
//                s_instance = GameObject.FindObjectOfType<T>();
//                if (FindObjectsOfType(typeof(T)).Length > 1) {
//                    Debug.Log("You have manyt hings.");
//                    return s_instance;
//                }
//                if (s_instance == null) {
//                    GameObject singleton = new GameObject();
//                    s_instance = singleton.AddComponent<T>();
//                    singleton.name = typeof(T).ToString();
//                    DontDestroyOnLoad(singleton);
//                }
//            }
//            return s_instance;
//        }
//    }
//}
