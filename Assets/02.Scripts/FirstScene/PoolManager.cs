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
            // Instantiate(����,��ġ,ȸ��) �ǽð� ������Ʈ �����Ҷ� ���
            // LookAt(��ġ) -> ��ġ�� ������ ȸ����Ų��.
        }
    }
}
