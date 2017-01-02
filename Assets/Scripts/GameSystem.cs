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
    public int lives = 5;
    public TowerScript towerScript;

    static GameSystem instance;
    List<GameObject> hostiles;
    bool isPaused;
    bool isGameStarted;
    int nextLevel;
    MasterSpawner spawnSystem;
    ObjectPool objectPool;

    string adUnitId = "ca-app-pub-5838986938071394/2684071660";
    string fullAdUnitId = "ca-app-pub-5838986938071394/9648935264";
    InterstitialAd interstitialAds;
    BannerView bannerView;

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
        RequestBannerAds();
        RequestInterstitialAds();
    }

    public void TakeDamage(int damage)
    {
        lives -= damage;
        if(lives > 0)
        {
            UpdateLives();
        }else
        {
            UpdateLives();
            GameOver();
        }
    }

    public void GameOver()
    {
        spawnSystem.StopSpawner();
        foreach(GameObject hostile in hostiles)
        {
            hostile.GetComponent<HostileMainScript>().SetSpeed(0);
        }
        infoUI.SetSkipButton(false);
        infoUI.SetFinalScore();
        towerScript.GameOverAnimation();
        controlUI.GameOver();
        isGameStarted = false;
        RemoveBannerAds();
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

    private void RequestBannerAds()
    {
        bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Bottom);
        AdRequest request = new AdRequest.Builder().AddTestDevice(AdRequest.TestDeviceSimulator).AddTestDevice("637993DD2A7CB6EA72E1DB3D321D9FA2").Build();
        bannerView.LoadAd(request);
        bannerView.Show();
    }

    private void RequestInterstitialAds()
    {
        interstitialAds = new InterstitialAd(fullAdUnitId);
        AdRequest request = new AdRequest.Builder().AddTestDevice(AdRequest.TestDeviceSimulator).AddTestDevice("637993DD2A7CB6EA72E1DB3D321D9FA2").Build();
        interstitialAds.LoadAd(request);
    }

    public void RemoveBannerAds()
    {
        bannerView.Hide();
    }

    public void ShowIntersitialAds()
    {
        interstitialAds.Show();
    }
    
    public void MoveToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
