using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InfoUI : MonoBehaviour {

    const string WAVE = "Wave: ";
    const string GOLD = "Gold: ";

    public Text goldText;
    public Text waveText;
    public Text timerText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
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
