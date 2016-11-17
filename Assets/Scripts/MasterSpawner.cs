using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MasterSpawner : MonoBehaviour
{

    static int MAX_WAVENUMER = 150;

    List<Spawner> leftSpawnerList;
    List<Spawner> rightSpawnerList;
    ObjectPool pool;

    int waveLevel = 1;

    int waveNumber = 10;
    float healthMultiplier = 1.0f;
    int goldMultiplier = 1;

    // Use this for initialization
    void Start()
    {
        leftSpawnerList = new List<Spawner>();
        rightSpawnerList = new List<Spawner>();
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
            leftSpawnerList[Random.Range(0, leftSpawnerList.Count)].SpawnEnemy(GetUnit(), goldMultiplier, healthMultiplier);
            rightSpawnerList[Random.Range(0, rightSpawnerList.Count)].SpawnEnemy(GetUnit(), goldMultiplier, healthMultiplier);
            yield return new WaitForSeconds(Random.Range(0f, 1f));
        }
    }

    private GameObject GetUnit()
    {
        switch(Random.Range(0, 2))
        {
            case 0:
                return GameSystem.GetGameSystem().GetObjectPool().GetSpider();
            case 1:
                return GameSystem.GetGameSystem().GetObjectPool().GetAssassin();
            default:
                return GameSystem.GetGameSystem().GetObjectPool().GetSpider();
        }
    }

    private void CalculateWaveLevel()
    {
        waveLevel++;
        if (waveNumber < MAX_WAVENUMER)
            waveNumber++;
        healthMultiplier *= 1.1f;
    }

    public void RemoveSpawner(Spawner[] spawnList)
    {
        foreach (Spawner spawn in spawnList)
        {
            if (spawn.isLeft)
                leftSpawnerList.Remove(spawn);
            else
                rightSpawnerList.Remove(spawn);
        }
        Debug.Log("Updating spawner list size " + leftSpawnerList.Count);
    }

    public void UpdateSpawnerList()
    {
        leftSpawnerList.Clear();
        rightSpawnerList.Clear();
        GameObject[] items = GameObject.FindGameObjectsWithTag(TagsAndLayers.TAG_SPAWNER);
        foreach (GameObject obj in items)
        {
            if (obj.GetComponent<Spawner>().isLeft)
                leftSpawnerList.Add(obj.GetComponent<Spawner>());
            else
                rightSpawnerList.Add(obj.GetComponent<Spawner>());
        }
    }
}
