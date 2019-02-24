using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T _instance = null;
    public static T Instance { get { return _instance; } }

    void Awake()
    {
        _instance = GetComponent<T>();
    }
}