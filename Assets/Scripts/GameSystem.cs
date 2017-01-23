using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;

public class GameSystem : MonoBehaviour
{

    public int gold;
    public InfoUI infoUI;
    public ControlUI controlUI;
    public int lives = 10;
    public TowerScript towerScript;

    static GameSystem instance;
    List<GameObject> hostiles;
    bool isPaused;
    bool isGameStarted;
    int nextLevel;
    MasterSpawner spawnSystem;
    ObjectPool objectPool;
    GameplayAchievementManager achievementManager;

    // Use this for initialization
    void Start()
    {
        Application.targetFrameRate = 30;
        if (instance != null)
            Destroy(instance);
        instance = this;
        hostiles = new List<GameObject>();
        objectPool = GetComponent<ObjectPool>();
        spawnSystem = GetComponent<MasterSpawner>();
        achievementManager = GetComponent<GameplayAchievementManager>();
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        StartCoroutine(initGame());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isGameStarted)
            controlUI.PauseButtonClicked();
    }

    void OnApplicationPause(bool isPause)
    {
        if (!isPause)
        {
            PTDAds.GetInstance().ShowIntersitialAds();
            if (isGameStarted)
                controlUI.PauseGame();
        }
    }

    IEnumerator initGame()
    {
        controlUI.EnableLoading();
        float temp = Time.realtimeSinceStartup;
        yield return objectPool.InitiatePooling();
        Debug.Log("Time for initiatepooling " + (Time.realtimeSinceStartup - temp));
        nextLevel = 120;
        GameObject.FindGameObjectWithTag(TagsAndLayers.TAG_TOWER).GetComponent<TowerFloorScript>().LoadTowerFloorToUI();
        isGameStarted = true;
        isPaused = false;
        UpdateLives();
        spawnSystem.CalculateGold();
        spawnSystem.UpdateSpawnerList();
        UpdateGoldValue();
        controlUI.DissableLoading();
        PTDAds.GetInstance().RequestBannerAds();
    }

    public void SpawnEnemyStart()
    {
        spawnSystem.StartSpawnEnemy();
    }

    public void TakeDamage(int damage)
    {
        if (spawnSystem.waveLevel < 50 && damage > 0)
        {
            achievementManager.TakeDamageBefore50();
        }
        if (lives > 0)
        {
            lives -= damage;
            if (lives > 0)
            {
                UpdateLives();
            }
            else
            {
                UpdateLives();
                GameOver();
            }
        }
    }

    public void GameOver()
    {
        spawnSystem.StopSpawner();
        foreach (GameObject hostile in hostiles)
        {
            hostile.GetComponent<HostileMainScript>().SetSpeed(0);
        }
        infoUI.SetSkipButton(false);
        towerScript.ClearTowerSelection();
        towerScript.GameOverAnimation();
        controlUI.GameOver();
        isGameStarted = false;
        PTDAds.GetInstance().RemoveBannerAds();
        achievementManager.GameOver();
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
        if (gold >= 5000)
            PTDPlay.AchFrugal();
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

    public void UpdateLives()
    {
        infoUI.UpdateLives(lives);
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

    public void UpdateScore(int score)
    {
        infoUI.UpdateScore(score);
    }

    public void UseMagic()
    {
        if (spawnSystem.waveLevel < 50)
            achievementManager.UseMagic();
    }

    public void MoveToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public GameplayAchievementManager AchievementManager()
    {
        return achievementManager;
    }
}
