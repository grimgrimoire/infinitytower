using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class ControlUI : MonoBehaviour, IPointerClickHandler{

    public static ControlUI control;

    public TowerScript tower;
    public GameObject pauseOverlay;

    TowerInternalUI towerInternalUI;
    TowerUpgradeUI towerUpgradeUI;

    public static ControlUI GetUI()
    {
        return control;
    }

    // Use this for initialization
    void Start () {
        control = this;
        towerInternalUI = GetComponentInChildren<TowerInternalUI>();
        towerUpgradeUI = GetComponentInChildren<TowerUpgradeUI>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PauseButtonClicked()
    {
        if (GameSystem.GetGameSystem().IsGamePaused())
        {
            Time.timeScale = 1;
            GameSystem.GetGameSystem().SetGamePaused(false);
            pauseOverlay.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            GameSystem.GetGameSystem().SetGamePaused(true);
            pauseOverlay.SetActive(true);
        }
    }

    public TowerInternalUI GetTowerInternalUI()
    {
        return towerInternalUI;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.pointerPressRaycast.gameObject.tag == "GameController")
        {
            RaycastHit2D hitRay = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(eventData.position), Vector2.zero);
            if (hitRay)
            {
                if (hitRay.collider.gameObject.tag == "AddTower")
                {
                    tower.AddFloor();
                }
                else if(hitRay.collider.gameObject.tag == "Tower")
                {
                    hitRay.collider.gameObject.GetComponent<TowerFloorScript>().LoadTowerFloorToUI();
                    towerInternalUI.ClearSelection();
                    towerUpgradeUI.ClearList();
                }
            }
        }
        else {

        }
    }

}
