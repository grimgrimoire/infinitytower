using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InfoUI : MonoBehaviour
{

    const string WAVE = "Wave: ";
    const string GOLD = "Gold: ";
    const string LIVE = "Lives: ";
    const string SCORE = "Score: ";

    public Text goldText;
    public Text waveText;
    public Text timerText;
    public Text livesText;
    public Text scoreText;
    public Text finalScore;
    public GameObject skipBtn1;
    public GameObject skipBtn2;
    public int score = 0;

    PoolClass addGoldText;

    // Use this for initialization
    void Start()
    {
        addGoldText = new PoolClass("Prefab/AddGold", 40);
        StartCoroutine(addGoldText.InitiatePooling(gameObject));
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateTimer(int duration)
    {
        timerText.text = "Next wave : " + duration + "s";
    }

    public void SetSkipButton(bool set)
    {
        skipBtn1.SetActive(set);
        skipBtn2.SetActive(set);
    }

    public void RemoveTimer()
    {
        timerText.text = "";
    }

    public void UpdateGold(int gold)
    {
        this.goldText.text = GOLD + gold;
    }

    public void UpdateLives(int live)
    {
        this.livesText.text = LIVE + live;
    }

    public void ShowAddGold(int gold)
    {
        if (gold == 0)
            return;
        GameObject text = addGoldText.GetFromPool();
        text.SetActive(true);
        if (gold > 0)
            text.GetComponent<Text>().text = "+ " + gold;
        else
            text.GetComponent<Text>().text = "- " + Mathf.Abs(gold);
    }

    public void UpdateWave(int wave)
    {
        this.waveText.text = WAVE + wave;
    }

    public void UpdateScore(int score)
    {
        this.score += score;
        scoreText.text = SCORE + this.score;
    }

    public void SetFinalScore()
    {
        finalScore.text = "Your score :\n " + score;
        finalScore.gameObject.SetActive(true);
        ScoreSystem.SaveData(score);
        if (score >= 100000)
            PTDPlay.AchStrategist();
        PTDPlay.Scoreboard(score);
    }

}
