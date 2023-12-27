using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    private ObjectPool objectPool;
    public float spawnRatemin = 0.5f;
    public float spawnRatemax = 3f;

    public Transform target;
    private float spawnRate;
    private float timeAfterSpawn;

    private void Awake()
    {
        objectPool = GetComponent<ObjectPool>();
    }
    void Start()
    {
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRatemin, spawnRatemax);

    }

    void Update()
    {
        timeAfterSpawn += Time.deltaTime;
        if (timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0f;
            GameObject bullet = objectPool.SpawnFromPool("bullet");
            bullet.transform.position = this.transform.position;
            bullet.SetActive(true);
            bullet.transform.LookAt(target);
            spawnRate = Random.Range(spawnRatemin, spawnRatemax);
            // Instantiate(원본,위치,회전) 실시간 오브젝트 생성할때 사용
            // LookAt(위치) -> 위치를 보도록 회전시킨다.
        }
    }
}
