using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MasterSpawner : MonoBehaviour
{

    const int MAX_WAVENUMER = 150;
    const int HIGHEST_COST = 6;

    List<Spawner> leftSpawnerList;
    List<Spawner> rightSpawnerList;

    List<GameObject> unitToSpawnList1;
    List<GameObject> unitToSpawnList2;

    ObjectPool pool;

    int waveLevel = 1;
    int waveNumber = 15;
    float healthMultiplier = 10f;
    int goldMultiplier = 1;

    // Use this for initialization
    void Start()
    {
        leftSpawnerList = new List<Spawner>();
        rightSpawnerList = new List<Spawner>();
        unitToSpawnList1 = new List<GameObject>();
        unitToSpawnList2 = new List<GameObject>();
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

    private IEnumerator SpawnBatch(int batch)
    {
        StartCoroutine(SpawnRightBatch(batch));
        GetUnitsToSpawn(unitToSpawnList1, batch);
        while (unitToSpawnList1.Count > 0)
        {
            Spawner spawn = GetSpawner(leftSpawnerList, unitToSpawnList1[0]);
            if (spawn != null)
                spawn.SpawnEnemy(unitToSpawnList1[0], goldMultiplier, healthMultiplier);
            unitToSpawnList1.RemoveAt(0);
            yield return new WaitForSeconds(Random.Range(0.25f, 1f));
        }
    }

    private IEnumerator SpawnRightBatch(int batch)
    {
        GetUnitsToSpawn(unitToSpawnList2, batch);
        while (unitToSpawnList2.Count > 0)
        {
            Spawner spawn = GetSpawner(rightSpawnerList, unitToSpawnList2[0]);
            if (spawn != null)
                spawn.SpawnEnemy(unitToSpawnList2[0], goldMultiplier, healthMultiplier);
            unitToSpawnList2.RemoveAt(0);
            yield return new WaitForSeconds(Random.Range(0.25f, 1f));
        }
    }

    private Spawner GetSpawner(List<Spawner> lists, GameObject isGroundUnit)
    {
        int random = Random.Range(0, lists.Count);
        while (lists[random].IsGroundSpawner() != isGroundUnit.GetComponent<HostileMainScript>().isGroundUnit && random < lists.Count - 1)
        {
            random = (random + 1) % lists.Count;
        }
        if (lists[random].IsGroundSpawner() == isGroundUnit)
            return lists[random];
        else return null;
    }

    private void GetUnitsToSpawn(List<GameObject> list, int costLeft)
    {
        while(costLeft > 0)
        {
            list.Add(GetRandomUnitByCost(ref costLeft));
        }
    }

    private GameObject GetRandomUnitByCost(ref int costleft)
    {
        switch (Random.Range(0, costleft < HIGHEST_COST ? costleft : HIGHEST_COST))
        {
            case 1:
                return null;
            default:
                return null;
        }
    }


    private ObjectPool GetObjectPool()
    {
        return GameSystem.GetGameSystem().GetObjectPool();
    }

    private GameObject GetUnitByCode(int code)
    {
        switch (code)
        {

            default:
                return GetObjectPool().GetSpider();
        }
    }

    private void CalculateWaveLevel()
    {
        waveLevel++;
        if (waveNumber < MAX_WAVENUMER)
            waveNumber++;
        //healthMultiplier *= 1.1f;
        GameSystem.GetGameSystem().UpdateWave(waveLevel);
    }

    private void CalculateAvailableEnemy()
    {
        bool airUnit = leftSpawnerList.Count > 5;
        bool elite = waveLevel % 5 == 0;
        bool heavy = waveLevel > 5;
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
