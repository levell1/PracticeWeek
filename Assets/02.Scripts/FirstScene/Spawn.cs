using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    private ObjectPool _objectPool;
    public float SpawnRatemin = 0.3f;
    public float SpawnRatemax = 1f;

    public Transform Target;
    private float _spawnRate;
    private float _timeAfterSpawn;

    public Transform[] SpawnPosition;
    private int _spawnCount;

    private void Awake()
    {
        _objectPool = GetComponent<ObjectPool>();
    }
    void Start()
    {
        _timeAfterSpawn = 0f;
        _spawnRate = Random.Range(SpawnRatemin, SpawnRatemax);
    }

    void Update()
    {
        _timeAfterSpawn += Time.deltaTime;
        if (_timeAfterSpawn >= 0.1f)
        {
            _spawnCount = Random.Range(0, SpawnPosition.Length);
            _timeAfterSpawn = 0f;

            GameObject bullet = _objectPool.SpawnFromPool("Bullet");

            bullet.transform.position = SpawnPosition[_spawnCount].position;
            bullet.transform.LookAt(Target);
            bullet.SetActive(true);

            _spawnRate = Random.Range(SpawnRatemin, SpawnRatemax);
            
        }
    }
}
