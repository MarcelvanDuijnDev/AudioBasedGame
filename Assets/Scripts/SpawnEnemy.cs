using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour 
{
    [Header("Settings")]
    [SerializeField] private GameObject _SpawnAreas = null;
    [SerializeField] private float _SpawnRate = 20;

    private float _SpawnRateReset;
    private Transform[] _SpawnArea;

    void Start()
    {
        _SpawnArea = new Transform[_SpawnAreas.transform.childCount];
        for (int i = 0; i < _SpawnArea.Length; i++)
        {
            _SpawnArea[i] = _SpawnAreas.transform.GetChild(i);
        }
        _SpawnRateReset = _SpawnRate;
    }

    void Update()
    {
        float audioIntensity = 0;
        for (int i = 0; i < 8; i++)
        {
            audioIntensity += ReadAudioFile._FreqBand[i];
        }
        _SpawnRate -= audioIntensity * Time.deltaTime;

        if (_SpawnRate <= 0)
        {
            int spawnid = Random.Range(0,_SpawnArea.Length);
            Vector3 vec = new Vector3(
                Random.Range(_SpawnArea[spawnid].transform.position.x - _SpawnArea[spawnid].transform.localScale.x*0.5f,_SpawnArea[spawnid].transform.position.x + _SpawnArea[spawnid].transform.localScale.x*0.5f), //x
                Random.Range(_SpawnArea[spawnid].transform.position.y - _SpawnArea[spawnid].transform.localScale.y*0.5f,_SpawnArea[spawnid].transform.position.y + _SpawnArea[spawnid].transform.localScale.y*0.5f), //y
                Random.Range(_SpawnArea[spawnid].transform.position.z - _SpawnArea[spawnid].transform.localScale.z*0.5f,_SpawnArea[spawnid].transform.position.z + _SpawnArea[spawnid].transform.localScale.z*0.5f)); //z
            Spawn_Enemy("EnemyA", vec);
            _SpawnRate += _SpawnRateReset;
        }
    }

    void Spawn_Enemy(string enemyname, Vector3 spawnLoc)
    {
        GameObject enemy = ObjectPool.POOL.GetObject(enemyname, false);
        enemy.transform.position = spawnLoc;
        enemy.SetActive(true);
    }
}