using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : Singleton<PoolManager>
{
    public Dictionary<GameObject, List<GameObject>> poolList = new();

    // �߰�
    public GameObject Push(GameObject pool)
    {
        return Push(pool, transform.position, pool.transform.rotation);
    }

    public GameObject Push(GameObject pool, Vector2 pos, Quaternion rot)
    {
        // ������ϸ� Dictionary �߰�
        if (!poolList.ContainsKey(pool))
            poolList.Add(pool, new List<GameObject>());

        GameObject g = Instantiate(pool, pos, rot);
        g.SetActive(true);
        poolList[pool].Add(g);

        return g;
    }

    // Ȱ��ȭ
    public GameObject Pop(GameObject pool)
    {
        return Pop(pool, transform.position, pool.transform.rotation);
    }

    public GameObject Pop(GameObject pool, Vector2 pos, Quaternion rot)
    {
        // dictionary ������ϸ� ���� �߰�
        if (!poolList.ContainsKey(pool)) return Push(pool, pos, rot);

        // active ��Ȱ��ȭ�Ȱ� ������ Ȱ��ȭ�ϰ� ����
        foreach (GameObject g in poolList[pool])
        {
            if (g.activeInHierarchy == false)
            {
                g.transform.SetPositionAndRotation(pos, rot);
                g.SetActive(true);
                return g;
            }
        }

        // ���� ���δ� Ȱ��ȭ ���¸� ���� �߰�
        return Push(pool, pos, rot);
    }

}
