using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InfoUI : MonoBehaviour {

    const string WAVE = "Wave: ";
    const string GOLD = "Gold: ";

    public Text goldText;
    public Text waveText;
    public Text timerText;
    public GameObject skipBtn1;
    public GameObject skipBtn2;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
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

    public void UpdateWave(int wave)
    {
        this.waveText.text = WAVE + wave;
    }

}
