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
            if (instance == null) instance = FindObjectOfType<T>(); // ���� �ִ��� �˻�
            if (instance == null)
            {
                instance = new GameObject().AddComponent<T>(); // ���� ������ ���� ����
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
