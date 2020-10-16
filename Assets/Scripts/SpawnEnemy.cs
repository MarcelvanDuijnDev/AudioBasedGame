using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour 
{
    public ObjectPool_Script[] objectPoolScripts;
    public GameObject spawnAreas;

    public float spawnRate;
    private float spawnRateReset;
    private Transform[] spawnArea;

    void Start()
    {
        Random.seed = 100;
        spawnArea = new Transform[spawnAreas.transform.childCount];
        for (int i = 0; i < spawnArea.Length; i++)
        {
            spawnArea[i] = spawnAreas.transform.GetChild(i);
        }
        spawnRateReset = spawnRate;
    }

    void Update()
    {
        float audioIntensity = 0;
        for (int i = 0; i < 8; i++)
        {
            audioIntensity += ReadAudioFile.freqBand[i];
        }
        spawnRate -= audioIntensity * Time.deltaTime;

        if (spawnRate <= 0)
        {
            int spawnid = Random.Range(0,spawnArea.Length);
            Vector3 vec = new Vector3(
                Random.Range(spawnArea[spawnid].transform.position.x - spawnArea[spawnid].transform.localScale.x*0.5f,spawnArea[spawnid].transform.position.x + spawnArea[spawnid].transform.localScale.x*0.5f), //x
                Random.Range(spawnArea[spawnid].transform.position.y - spawnArea[spawnid].transform.localScale.y*0.5f,spawnArea[spawnid].transform.position.y + spawnArea[spawnid].transform.localScale.y*0.5f), //y
                Random.Range(spawnArea[spawnid].transform.position.z - spawnArea[spawnid].transform.localScale.z*0.5f,spawnArea[spawnid].transform.position.z + spawnArea[spawnid].transform.localScale.z*0.5f)); //z
            Spawn_Enemy(0, vec);
            Debug.Log("SpawnEnemy");
            spawnRate += spawnRateReset;
        }
    }

    void Spawn_Enemy(int enemyIndex, Vector3 spawnLoc)
    {
        for (int i = 0; i < objectPoolScripts[enemyIndex].objects.Count; i++)
        {
            if (!objectPoolScripts[enemyIndex].objects[i].activeInHierarchy)
            {
                objectPoolScripts[enemyIndex].objects[i].transform.position = spawnLoc;
                //objectPoolScripts[enemyIndex].objects[i].transform.rotation =;
                objectPoolScripts[enemyIndex].objects[i].SetActive(true);
                break;
            }
        }
    }
}