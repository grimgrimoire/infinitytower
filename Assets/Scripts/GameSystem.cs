using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GameSystem : MonoBehaviour
{

    public int gold;
    public InfoUI infoUI;
    public ControlUI controlUI;

    static GameSystem instance;
    List<GameObject> hostiles;
    bool isPaused;
    bool isGameStarted;
    int nextLevel;
    MasterSpawner spawnSystem;
    ObjectPool objectPool;

    // Use this for initialization
    void Start()
    {
        if (instance != null)
            Destroy(instance);
        instance = this;
        hostiles = new List<GameObject>();
        objectPool = GetComponent<ObjectPool>();
        spawnSystem = GetComponent<MasterSpawner>();
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        StartCoroutine(initGame());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator initGame()
    {
        float temp = Time.realtimeSinceStartup;
        yield return objectPool.InitiatePooling();
        Debug.Log("Time for initiatepooling " + (Time.realtimeSinceStartup - temp));
        nextLevel = 120;
        GameObject.FindGameObjectWithTag(TagsAndLayers.TAG_TOWER).GetComponent<TowerFloorScript>().LoadTowerFloorToUI();
        isGameStarted = true;
        isPaused = false;
        spawnSystem.UpdateSpawnerList();
        spawnSystem.StartSpawnEnemy();
        UpdateGoldValue();
        controlUI.DissableLoading();
    }

    public ObjectPool GetObjectPool()
    {
        return objectPool;
    }

    public MasterSpawner GetSpawnSystem()
    {
        return spawnSystem;
    }

    public void SetGamePaused(bool pause)
    {
        isPaused = pause;
    }

    public bool IsGamePaused()
    {
        return isPaused;
    }

    public bool IsGameStarted()
    {
        return isGameStarted;
    }

    public static GameSystem GetGameSystem()
    {
        return instance;
    }

    public void AddHostile(GameObject hostile)
    {
        hostiles.Add(hostile);
    }

    public void RemoveHostile(GameObject hostile)
    {
        hostiles.Remove(hostile);
    }

    public List<GameObject> GetHostiles()
    {
        return hostiles;
    }

    public void AddGold(int value)
    {
        gold += value;
        infoUI.ShowAddGold(value);
        UpdateGoldValue();
    }

    public int GetGold()
    {
        return gold;
    }

    public void UpdateGoldValue()
    {
        infoUI.UpdateGold(gold);
    }

    public void UpdateWave(int wave)
    {
        infoUI.UpdateWave(wave);
    }

    public ControlUI GetControlUI()
    {
        return controlUI;
    }

    public InfoUI GetInfoUI()
    {
        return infoUI;
    }

    public void SkipWave(int timer)
    {
        AddGold(timer > 9 ? 100 : timer * 10);
    }

}
