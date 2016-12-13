﻿using UnityEngine;
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
    int waveNumber = 10;
    public float healthMultiplier = 1f;
    public float goldMultiplier = 1;
    int nextWaveTimer = -1;

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
            CalculateWaveLevel();
            yield return WaveEndTimer();
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
        /////////////////////////////////////

        costleft--;
        return GetObjectPool().GetZeppelinLarge();

        ////////////////////////////////////
        int highestCost = GetHighestCost();
        highestCost = highestCost < costleft ? highestCost : costleft == 4 ? 3 : costleft;
        return Ratio(30, 30, 20, 20, highestCost, ref costleft);
    }

    private GameObject Ratio(int cost1, int cost2, int cost3, int cost4, int highestCost, ref int costleft)
    {
        int val = RandomizeUnitCost(cost1, cost2, cost3, cost4, highestCost);
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

    private int RandomizeUnitCost(int cost1, int cost2, int cost3, int cost4, int highestCost)
    {
        int val = 0;
        if (highestCost > 1)
            val = Random.Range(0, CalculateCost(cost1 + cost2));
        else if (highestCost > 2)
            val = Random.Range(0, CalculateCost(cost1 + cost2 + cost3));
        else if (highestCost > 3)
            val = Random.Range(0, 600);
        return val;
    }

    private int CalculateCost(int cost)
    {
        return (600 * cost / 100);
    }

    private int GetHighestCost()
    {
        if (waveLevel < 5)
            return 1;
        else if (waveLevel < 10)
            return 2;
        else if (waveLevel < 15)
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
        switch (Random.Range(0, CanHaveAirUnit() ? 3 : 2))
        {
            case 0:
                return GetObjectPool().GetNinja();
            case 1:
                return GetObjectPool().GetAssassin();
            case 2:
                return GetObjectPool().GetBalloon();
            default:
                return GetObjectPool().GetNinja();
        }
    }

    private GameObject GetCost3Unit()
    {
        switch (Random.Range(0, CanHaveAirUnit() ? 2 : 1))
        {
            case 0:
                return GetObjectPool().GetSoldier();
            case 1:
                return GetObjectPool().GetZeppelin();
            default:
                return GetObjectPool().GetSoldier();
        }
    }

    private GameObject GetCost5Unit()
    {
        switch (Random.Range(0, CanHaveAirUnit() ? 2 : 1))
        {
            case 0:
                return GetObjectPool().GetSoldier();
            case 1:
                return GetObjectPool().GetZeppelin();
            default:
                return GetObjectPool().GetSoldier();
        }
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
        if (waveNumber < MAX_WAVENUMER && waveLevel % 5 == 0)
            waveNumber += 5;
        if (waveLevel % 5 == 0)
        {
            healthMultiplier += 0.3f;
            goldMultiplier += 0.3f;
        }else
        {
            healthMultiplier += 0.05f;
            goldMultiplier += 0.05f;
        }
        GameSystem.GetGameSystem().UpdateWave(waveLevel);
    }

    IEnumerator WaveEndTimer()
    {
        nextWaveTimer = 20;
        GameSystem.GetGameSystem().GetInfoUI().SetSkipButton(true);
        GameSystem.GetGameSystem().GetInfoUI().UpdateTimer(nextWaveTimer);
        while (nextWaveTimer > -1)
        {
            yield return new WaitForSeconds(1);
            nextWaveTimer -= 1;
            GameSystem.GetGameSystem().GetInfoUI().UpdateTimer(nextWaveTimer);
        }
        GameSystem.GetGameSystem().GetInfoUI().RemoveTimer();
        GameSystem.GetGameSystem().GetInfoUI().SetSkipButton(false);
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

    public void SkipWave()
    {
        nextWaveTimer = 0;
        GameSystem.GetGameSystem().GetInfoUI().SetSkipButton(false);
    }
}
