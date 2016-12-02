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

    int waveLevel = 20;
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
            GameObject unit = GetRandomUnitByCost(ref costLeft);
            if (unit != null)
                list.Add(unit);
        }
    }

    private GameObject GetRandomUnitByCost(ref int costleft)
    {
        int highestCost = GetHighestCost();
        highestCost = highestCost < costleft ? highestCost : costleft == 4 ? 3 : costleft;
        int val = Random.Range(0, (highestCost + 1) * 120);
        return Ratio(30, 30, 20, 20, val, ref costleft);
    }

    private GameObject Ratio(int cost1, int cost2, int cost3, int cost4, int val, ref int costleft)
    {
        if (val <= CalculateCost(cost1))
        {
            costleft -= 1;
            return GetCost1Unit();
        }
        else if (val > CalculateCost(cost1) && val <= CalculateCost(cost1 + cost2))
        {
            costleft -= 2;
            return GetCost2Unit();
        }
        else if (val > CalculateCost(cost1 + cost2) && val <= CalculateCost(cost1 + cost2 + cost3))
        {
            costleft -= 3;
            return GetCost3Unit();
        }
        else
        {
            costleft -= 5;
            return GetCost5Unit();
        }
    }

    private int CalculateCost(int cost)
    {
        return (600 * cost / 100);
    }

    private int GetHighestCost()
    {
        if (waveNumber < 5)
            return 1;
        else if (waveNumber < 10)
            return 2;
        else if (waveNumber < 15)
            return 3;
        else return 4;
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

    private GameObject GetCost2Unit()
    {
        return GetObjectPool().GetNinja();
    }

    private GameObject GetCost3Unit()
    {
        return GetObjectPool().GetAssassin();
    }

    private GameObject GetCost5Unit()
    {
        return GetObjectPool().GetSoldier();
    }

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
