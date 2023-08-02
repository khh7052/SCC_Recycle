using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public bool onDontDestroy = false;

    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null) instance = FindObjectOfType<T>(); // 씬에 있는지 검색
            if (instance == null)
            {
                instance = new GameObject().AddComponent<T>(); // 씬에 없으면 새로 생성
                instance.name = typeof(T).Name;
            }

            return instance;
        }
        set { instance = value; }
    }

    public virtual void Awake()
    {
        if (instance)
        {
            // if(instance != this) Destroy(gameObject);
        }
        else
        {
            if (onDontDestroy) DontDestroyOnLoad(gameObject);
        }
    }

}
