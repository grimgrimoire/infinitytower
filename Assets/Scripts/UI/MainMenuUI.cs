using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    public GameObject startButton;
    public GameObject recordButton;
    public GameObject overlay;
    public GameObject tutorial;
    public Text version;
    public Text record1;
    public Text record2;
    public Text record3;
    public Text record4;
    public Text record5;
    public Text record6;

    // Use this for initialization
    void Start()
    {
        version.text = "Version " + Application.version;
        PTDAds.GetInstance().RequestInterstitialAds();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (tutorial.activeSelf)
                HideTutorial();
            else if (overlay.activeSelf)
                HideOverlay();
            else
                Application.Quit();
        }

    }

    public void StartButtonPressed()
    {
        SceneManager.LoadScene(1);
    }

    public void RecordButtonPressed()
    {
        ShowRecord();
    }

    public void ShowTutorial()
    {
        tutorial.SetActive(true);
    }

    public void HideTutorial()
    {
        tutorial.SetActive(false);
    }

    public void HideOverlay()
    {
        overlay.SetActive(false);
    }

    private void ShowRecord()
    {
        overlay.SetActive(true);
        List<int> datas = ScoreSystem.LoadData();
        record1.text = datas[0] + "";
        record2.text = datas[1] + "";
        record3.text = datas[2] + "";
        record4.text = datas[3] + "";
        record5.text = datas[4] + "";
        record6.text = datas[5] + "";
    }
}

