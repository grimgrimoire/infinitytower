using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class ControlUI : MonoBehaviour, IPointerClickHandler, IDragHandler, IBeginDragHandler, IEndDragHandler{

    public static ControlUI control;

    public TowerScript tower;
    public GameObject pauseOverlay;
    public Camera mainCamera;
    public DialogUI dialogUI;
    public GameObject loadingOverlay;

    TowerInternalUI towerInternalUI;
    TowerUpgradeUI towerUpgradeUI;

    Vector2 moveDirection;

    bool isDragging;
    float minX = -10;
    float maxX = 10;
    float minY = 1.45f;

    public static ControlUI GetUI()
    {
        return control;
    }

    // Use this for initialization
    void Start () {
        control = this;
        towerInternalUI = GetComponentInChildren<TowerInternalUI>();
        towerUpgradeUI = GetComponentInChildren<TowerUpgradeUI>();
        minX -= mainCamera.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
        maxX -= mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
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
        if(eventData.pointerPressRaycast.gameObject.tag == "GameController" && !isDragging)
        {
            RaycastHit2D hitRay = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(eventData.position), Vector2.zero);
            if (hitRay)
            {
                if (hitRay.collider.gameObject.tag == "AddTower")
                {
                    AddNewFloor();
                }
                else if(hitRay.collider.gameObject.tag == "Tower")
                {
                    LoadTowerFloorToUI(hitRay.collider.gameObject);
                }
            }
        }
        else {

        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        moveDirection = -eventData.delta;
        if (((moveDirection.x * 0.01f) + mainCamera.transform.position.x < minX)  || ((moveDirection.x * 0.01f) + mainCamera.transform.position.x > maxX))
        {
            moveDirection = new Vector2(0, moveDirection.y);
        }
        if ((moveDirection.y * 0.01f) + mainCamera.transform.position.y < minY)
        {
            moveDirection = new Vector2(moveDirection.x, 0);
        }
        if (eventData.pointerPressRaycast.gameObject.tag == "GameController")
        {
            mainCamera.transform.Translate(moveDirection * 0.01f);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDragging = false;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        isDragging = true;
    }

    private void AddNewFloor()
    {
        tower.AddFloorDialog();
    }

    private void LoadTowerFloorToUI(GameObject tower)
    {
        tower.GetComponent<TowerFloorScript>().LoadTowerFloorToUI();
        towerInternalUI.ClearSelection();
        towerUpgradeUI.ClearList();
    }

    public void DissableLoading()
    {
        loadingOverlay.SetActive(false);
    }
}
