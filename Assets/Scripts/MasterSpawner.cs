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

    public int multiplierNumber = 1;

    int waveLevel = 1;
    int waveNumber = 15;
    public float healthMultiplier = 1f;
    public int goldMultiplier = 1;

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
            int batch1 = waveNumber * multiplierNumber / 5;
            int batch2 = waveNumber * multiplierNumber / 3;
            int batch3 = waveNumber * multiplierNumber / 2;

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
        int random;
        if (isGroundUnit.GetComponent<HostileMainScript>().isGroundUnit)
            random = Random.Range(0, lists.Count);
        else
            random = random = Random.Range(5, lists.Count);
        while (lists[random].IsGroundSpawner() != isGroundUnit.GetComponent<HostileMainScript>().isGroundUnit && random < lists.Count - 1)
        {
            random = (random + 1) % lists.Count;
        }
        if (lists[random].IsGroundSpawner() == isGroundUnit.GetComponent<HostileMainScript>().isGroundUnit)
            return lists[random];
        else return lists[0];
    }

    private void GetUnitsToSpawn(List<GameObject> list, int costLeft)
    {
        while (costLeft > 0)
        {
            list.Add(GetRandomUnitByCost(ref costLeft));
        }
    }

    private GameObject GetRandomUnitByCost(ref int costleft)
    {
        int val = Random.Range(0, costleft < HIGHEST_COST ? costleft : HIGHEST_COST);
        costleft -= 1;
        return GetCost1Unit();
    }

    private GameObject GetCost1Unit()
    {
        switch (Random.Range(0, CanHaveAirUnit() ? 2 : 1))
        {
            case 0:
                return GetObjectPool().GetSpider();
            case 1:
                return GetObjectPool().GetBat();
            default:
                return GetObjectPool().GetSpider();
        }
    }

    //private GameObject GetCost2Unit()
    //{

    //}

    //private GameObject GetCost5Unit()
    //{

    //}

    //private GameObject GetCost10Unit()
    //{

    //}

    private bool CanHaveAirUnit()
    {
        return leftSpawnerList.Count > 5;
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
