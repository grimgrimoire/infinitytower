using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MasterSpawner : MonoBehaviour
{

    static int MAX_WAVENUMER = 100;

    List<Spawner> spawnerList;
    ObjectPool pool;

    int waveLevel = 1;

    int waveNumber = 40;
    float healthMultiplier = 1.0f;
    int goldMultiplier = 1;

    // Use this for initialization
    void Start()
    {
        spawnerList = new List<Spawner>();
        pool = GetComponent<ObjectPool>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartSpawnEnemy()
    {
        StartCoroutine(SpawnSet());
    }


    private IEnumerator SpawnSet()
    {
        while (GameSystem.GetGameSystem().IsGameStarted())
        {
            int batch1 = waveNumber / 5;
            int batch2 = waveNumber / 3;
            int batch3 = waveNumber / 2;

            Debug.Log("Spawn at " + batch1 + " " + batch2 + " " + batch3);
            Debug.Log("Spawn with " + goldMultiplier + " X Gold" + " , " + healthMultiplier + " X Health");

            yield return SpawnBatch(batch1);
            yield return new WaitForSeconds(5);
            yield return SpawnBatch(batch2);
            yield return new WaitForSeconds(5);
            yield return SpawnBatch(batch3);
            yield return new WaitForSeconds(10);
            CalculateWaveLevel();
        }
    }

    private IEnumerator SpawnBatch(int number)
    {
        while (number > 0)
        {
            number--;
            spawnerList[Random.Range(0, spawnerList.Count)].SpawnEnemy(pool.GetSpider(), goldMultiplier, healthMultiplier);
            yield return new WaitForSeconds(Random.Range(0f, 1f));
        }
    }

    private void CalculateWaveLevel()
    {
        waveLevel++;

    }

    public void RemoveSpawner(Spawner[] spawnList)
    {
        foreach (Spawner spawn in spawnList)
        {
            spawnerList.Remove(spawn);
        }
        Debug.Log("Updating spawner list size " + spawnerList.Count);
    }

    public void UpdateSpawnerList()
    {
        spawnerList.Clear();
        GameObject[] items = GameObject.FindGameObjectsWithTag(TagsAndLayers.TAG_SPAWNER);
        foreach (GameObject obj in items)
        {
            spawnerList.Add(obj.GetComponent<Spawner>());
        }
        Debug.Log("Updating spawner list size " + spawnerList.Count);
    }
}
