using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingleTon<T> : MonoBehaviour where T : MonoBehaviour
{
    static bool ShuttingDown;
    static T instance;
    public static T Instance
    {
        get
        {
            if(ShuttingDown)
            {
                Debug.LogWarning("[Instance]instance"+typeof(T)+"is already existring.");
                return null; 

            }
            if (!instance)
            {
                instance = (T)FindObjectOfType(typeof(T));
                if (!instance)
                {
                    GameObject temp = new GameObject(typeof(T).ToString());
                    instance = temp.AddComponent<T>();
                }
            }
            return instance;
        }


    }

    private void OnApplicationQuit()
    {
        ShuttingDown = true;
    }
}
