using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonOn : MonoBehaviour
{
    void Start()
    {
        Debug.Log("===================== Singleton Pattern =====================");
        Singleton s1 = Singleton.Instance();
        Singleton s2 = Singleton.Instance();

        if (s1 == s2)
        {
            Debug.Log("Objects are the same instance");
        }

        else
           Debug.Log("Objects are the different insatnce");
    }
}
