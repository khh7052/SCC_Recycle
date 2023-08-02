using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjInstantiate : MonoBehaviour
{
    [SerializeField] GameObject Prefabobj;
    [SerializeField] Transform target;

    public float spawnInterval = 3f;    // 생성 간격
    public float DestroyInterval = 7f;    // 파괴 시간

    private void Start()
    {
        // 일정 간격으로 SpawnObject 메서드 호출
        InvokeRepeating("SpawnObject", 0f, spawnInterval);
    }

    private void SpawnObject()
    {
        // 프리팹 오브젝트 생성
        GameObject spawnedObject = Instantiate(Prefabobj, target.position, Quaternion.identity);

        // 생성된 오브젝트를 자식 오브젝트로 설정
        spawnedObject.transform.SetParent(transform);

        Destroy(spawnedObject, DestroyInterval);

    }


}
