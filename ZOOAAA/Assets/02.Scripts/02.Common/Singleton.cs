using UnityEngine;
using System.Collections;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{

    private static T _instance = null;
    public static T Instance
    {
        get
        {
            if (null == _instance)
                _instance = FindObjectOfType(typeof(T)) as T;

            return _instance;
        }
    }
}