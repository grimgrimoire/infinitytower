using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InfoUI : MonoBehaviour {

    public Text goldText;
    public Text levelText;
    public Text timerText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void UpdateGold(int gold)
    {
        this.goldText.text = "Gold: " + gold;
    }

}
