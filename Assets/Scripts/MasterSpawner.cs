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

    public int waveLevel = 1;
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
        GameSystem.GetGameSystem().UpdateWave(waveLevel);
        waveLevel -= 1;
        while (GameSystem.GetGameSystem().IsGameStarted())
        {
            CalculateWaveLevel();
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
            yield return WaveEndTimer();
        }
    }

    public void CalculateGold()
    {
        int startingGold;
        int tocal = waveLevel;
        startingGold = CalculateGoldAtWave(tocal - 1);
        GameSystem.GetGameSystem().AddGold(startingGold);
    }

    private int CalculateGoldAtWave(int wave)
    {
        if (wave > 5)
        {
            if (wave % 5 == 0)
            {
                return CalculateGoldAtWave(wave - 1) + (((Mathf.FloorToInt(wave / 5) * 100) + 200));
            }
            else
            {
                return CalculateGoldAtWave(wave - (wave % 5)) + (((Mathf.FloorToInt(wave / 5) * 100) + 200) * (wave % 5));
            }
        }
        else
        {
            if (wave == 0)
                return 100;
            else
                return (200 * wave) + (wave % 5 == 0 ? 200 : 100);
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
        try
        {
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
        catch
        {
            return null;
        }
    }

    private void GetUnitsToSpawn(List<GameObject> list, int costLeft)
    {
        if (waveLevel == 40 && costLeft == 25)
            list.Add(GetObjectPool().GetKnight());
        else if (waveLevel == 45 && costLeft == 30)
            list.Add(GetObjectPool().GetDragon());

        while (costLeft > 0)
        {
            GameObject unit = GetRandomUnitByCost(ref costLeft);
            if (unit != null)
                list.Add(unit);
        }
    }

    private GameObject GetRandomUnitByCost(ref int costLeft)
    {
        int typeFly = Random.Range(0, leftSpawnerList.Count - 3);
        if (typeFly < 2)
        {
            return GetRandomGroundUnit(ref costLeft);
        }
        else
        {
            return GetRandomAirUnit(ref costLeft);
        }
    }

    private GameObject GetRandomAirUnit(ref int costLeft)
    {
        if (waveLevel < 10) // Spiders
            return GetRandomAir1(ref costLeft);
        else if (waveLevel < 15) // Light medium
            return GetRandomAir2(ref costLeft);
        else if (waveLevel < 25) // Heavy
            return GetRandomAir3(ref costLeft);
        else if (waveLevel <= 45)
            return GetRandomAir4(ref costLeft);// Special
        else
            return GetRandomAir5(ref costLeft);
    }

    private GameObject GetRandomAir1(ref int costLeft)
    {
        costLeft -= 1;
        return GetObjectPool().GetBat();
    }

    private GameObject GetRandomAir2(ref int costLeft)
    {
        int seed = Random.Range(0, 101);
        if (seed < 75 || costLeft == 1)
        {
            costLeft -= 1;
            return GetObjectPool().GetBat();
        }
        else
        {
            costLeft -= 2;
            return GetObjectPool().GetBalloon();
        }
    }

    private GameObject GetRandomAir3(ref int costLeft)
    {
        int seed = Random.Range(0, 101);
        if (seed < 50 || costLeft == 1)
        {
            costLeft -= 1;
            return GetObjectPool().GetBat();
        }
        else if (seed < 90 || costLeft == 2)
        {
            costLeft -= 2;
            return GetObjectPool().GetBalloon();
        }
        else
        {
            costLeft -= 3;
            return GetObjectPool().GetZeppelin();
        }
    }

    private GameObject GetRandomAir4(ref int costLeft)
    {
        int seed = Random.Range(0, 101);
        if (seed < 50 || costLeft == 1)
        {
            costLeft -= 1;
            return GetObjectPool().GetBat();
        }
        else if (seed < 80 || costLeft == 2)
        {
            costLeft -= 2;
            return GetObjectPool().GetBalloon();
        }
        else if (seed < 95 || costLeft == 3)
        {
            costLeft -= 3;
            return GetObjectPool().GetZeppelin();
        }
        else
        {
            costLeft -= 8;
            return GetObjectPool().GetZeppelinLarge();
        }
    }

    private GameObject GetRandomAir5(ref int costLeft)
    {
        int seed = Random.Range(0, 101);
        if (seed < 50 || costLeft == 1)
        {
            costLeft -= 1;
            return GetObjectPool().GetBat();
        }
        else if (seed < 80 || costLeft == 2)
        {
            costLeft -= 2;
            return GetObjectPool().GetBalloon();
        }
        else if (seed < 94 || costLeft == 3)
        {
            costLeft -= 3;
            return GetObjectPool().GetZeppelin();
        }
        else if (seed < 99 || costLeft == 8)
        {
            costLeft -= 8;
            return GetObjectPool().GetZeppelinLarge();
        }
        else
        {
            costLeft -= 10;
            return GetObjectPool().GetDragon();
        }
    }

    private GameObject GetRandomGroundUnit(ref int costLeft)
    {
        if (waveLevel < 10)
            return GetRandomGround1(ref costLeft); // Light
        else if (waveLevel < 15)
            return GetRandomGround2(ref costLeft); // Medium
        else if (waveLevel < 20)
            return GetRandomGround3(ref costLeft); // Heavy
        else if (waveLevel <= 40)
            return GetRandomGround4(ref costLeft); // Specials
        else
            return GetRandomGround5(ref costLeft);
    }

    private GameObject GetRandomGround1(ref int costLeft)
    {
        costLeft -= 1;
        return GetObjectPool().GetSpider();
    }

    private GameObject GetRandomGround2(ref int costLeft)
    {
        int seed = Random.Range(0, 101);
        if (seed < 40 || costLeft == 1)
        {
            costLeft -= 1;
            return GetObjectPool().GetSpider();
        }
        else if (seed < 70)
        {
            costLeft -= 2;
            return GetObjectPool().GetAssassin();
        }
        else
        {
            costLeft -= 2;
            return GetObjectPool().GetNinja();
        }
    }

    private GameObject GetRandomGround3(ref int costLeft)
    {
        int seed = Random.Range(0, 101);
        if (seed < 40 || costLeft == 1)
        {
            costLeft -= 1;
            return GetObjectPool().GetSpider();
        }
        else if (seed < 80 || costLeft == 2)
        {
            costLeft -= 2;
            if (seed < 60)
                return GetObjectPool().GetAssassin();
            else
                return GetObjectPool().GetNinja();
        }
        else
        {
            costLeft -= 3;
            if (seed < 90)
                return GetObjectPool().GetSoldier();
            else
                return GetObjectPool().GetShield();
        }
    }

    private GameObject GetRandomGround4(ref int costLeft)
    {
        int seed = Random.Range(0, 101);
        if (seed < 30 || costLeft == 1)
        {
            costLeft -= 1;
            return GetObjectPool().GetSpider();
        }
        else if (seed < 80 || costLeft == 2)
        {
            costLeft -= 2;
            if (seed < 55)
                return GetObjectPool().GetAssassin();
            else
                return GetObjectPool().GetNinja();
        }
        else if (seed < 97 || costLeft == 3)
        {
            costLeft -= 3;
            if (seed < 87)
                return GetObjectPool().GetSoldier();
            else
                return GetObjectPool().GetShield();
        }
        else
        {
            costLeft -= 5;
            return GetObjectPool().GetLargeSpider();
        }
    }

    private GameObject GetRandomGround5(ref int costLeft)
    {
        int seed = Random.Range(0, 101);
        if (seed < 30 || costLeft == 1)
        {
            costLeft -= 1;
            return GetObjectPool().GetSpider();
        }
        else if (seed < 80 || costLeft == 2)
        {
            costLeft -= 2;
            if (seed < 55)
                return GetObjectPool().GetAssassin();
            else
                return GetObjectPool().GetNinja();
        }
        else if (seed < 94 || costLeft == 3)
        {
            costLeft -= 3;
            if (seed < 87)
                return GetObjectPool().GetSoldier();
            else
                return GetObjectPool().GetShield();
        }
        else if(seed < 99 || costLeft == 5)
        {
            costLeft -= 5;
            return GetObjectPool().GetLargeSpider();
        }
        else
        {
            costLeft -= 10;
            return GetObjectPool().GetKnight();
        }
    }

    private ObjectPool GetObjectPool()
    {
        return GameSystem.GetGameSystem().GetObjectPool();
    }

    private void CalculateWaveLevel()
    {
        waveLevel++;
        waveNumber = 10 + (Mathf.FloorToInt(waveLevel / 5) * 5) + (Mathf.FloorToInt(waveLevel / 40f) * 5 * Mathf.CeilToInt((waveLevel - 40) / 5f));
        Debug.Log(waveNumber);
        //healthMultiplier = 1 + (
        //    (waveLevel - (1 + Mathf.FloorToInt(waveLevel / 5))) * SmallIncrement()
        //    +
        //    ((Mathf.FloorToInt(waveLevel / 5)) * LargeIncrement())
        //    )
        //    +
        //    (Mathf.FloorToInt(waveLevel / 20f) * 0.2f * (waveLevel - 20))
        //    +
        //    (Mathf.FloorToInt(waveLevel / 40f) * 4)
        //    +
        //    (Mathf.FloorToInt(waveLevel / 100f) * 1 * (waveLevel - 100))
        //    ;
        healthMultiplier = 1 + (
               (waveLevel - (1 + Mathf.FloorToInt(waveLevel / 5f))) * SmallIncrement()
               +
               ((Mathf.FloorToInt(waveLevel / 5f)) * LargeIncrement())
               )
               ;
        if (waveLevel >= 40)
        {
            healthMultiplier += (Mathf.FloorToInt((waveLevel - 20) / 20f) * 2);
            healthMultiplier += (waveLevel - 40) * 0.2f;
            healthMultiplier += (Mathf.FloorToInt(waveLevel / 5f) * 0.2f);
            healthMultiplier += (
                (Mathf.FloorToInt((waveLevel - 40) / 20f) * 0.1f * (waveLevel - 40))
                );
        }
        if (waveLevel > 80)
        {
            healthMultiplier += (waveLevel - 80) * 0.4f;
            healthMultiplier += (Mathf.FloorToInt((waveLevel - 80) / 5f) * 0.6f);
            healthMultiplier += (
                (Mathf.FloorToInt((waveLevel - 80) / 20f) * 0.4f * (waveLevel - 80))
                );
        }
        GameSystem.GetGameSystem().UpdateWave(waveLevel);
    }

    private float SmallIncrement()
    {
        if (waveLevel <= 20)
            return 0.2f;
        else
            return 0.3f;
    }

    private float LargeIncrement()
    {
        if (waveLevel <= 20)
            return 0.6f;
        else
            return 0.6f;
    }

    public void StopSpawner()
    {
        StopAllCoroutines();
    }

    IEnumerator WaveEndTimer()
    {
        nextWaveTimer = 21;
        GameSystem.GetGameSystem().GetInfoUI().SetSkipButton(true);
        GameSystem.GetGameSystem().GetInfoUI().UpdateTimer(nextWaveTimer);
        while (nextWaveTimer > 0)
        {
            nextWaveTimer -= 1;
            GameSystem.GetGameSystem().GetInfoUI().UpdateTimer(nextWaveTimer);
            yield return new WaitForSeconds(1);
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
        GameSystem.GetGameSystem().SkipWave(nextWaveTimer);
        nextWaveTimer = 0;
        GameSystem.GetGameSystem().GetInfoUI().SetSkipButton(false);
    }
}
