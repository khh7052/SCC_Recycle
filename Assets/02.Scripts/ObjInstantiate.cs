using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjInstantiate : MonoBehaviour
{
    [SerializeField] GameObject Prefabobj;
    [SerializeField] Transform target;

    public float spawnInterval = 3f;    // ���� ����
    public float DestroyInterval = 7f;    // �ı� �ð�

    private void Start()
    {
        // ���� �������� SpawnObject �޼��� ȣ��
        InvokeRepeating("SpawnObject", 0f, spawnInterval);
    }

    private void SpawnObject()
    {
        // ������ ������Ʈ ����
        GameObject spawnedObject = Instantiate(Prefabobj, target.position, Quaternion.identity);

        // ������ ������Ʈ�� �ڽ� ������Ʈ�� ����
        spawnedObject.transform.SetParent(transform);

        Destroy(spawnedObject, DestroyInterval);

    }


}
