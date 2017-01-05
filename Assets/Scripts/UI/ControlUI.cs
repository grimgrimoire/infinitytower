using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using UnityEngine.SceneManagement;

public class ControlUI : MonoBehaviour, IPointerClickHandler, IDragHandler, IBeginDragHandler, IEndDragHandler, DialogInterface
{

    public static ControlUI control;

    public TowerScript tower;
    public GameObject pauseOverlay;
    public Camera mainCamera;
    public DialogUI dialogUI;
    public GameObject loadingOverlay;
    public GameObject pauseButton;
    public GameObject returnButton;
    public GameObject pauseMenu;
    public GameObject tipsDialog;
    public GameObject startButton1;
    public GameObject startButton2;

    TowerInternalUI towerInternalUI;
    TowerUpgradeUI towerUpgradeUI;

    Vector2 moveDirection;

    bool isDragging;
    float minX = -10;
    float maxX = 10;
    float minY = 1.45f;
    float maxY = 9;
    bool canMove = true;

    public static ControlUI GetUI()
    {
        return control;
    }

    // Use this for initialization
    void Start()
    {
        control = this;
        towerInternalUI = GetComponentInChildren<TowerInternalUI>();
        towerUpgradeUI = GetComponentInChildren<TowerUpgradeUI>();
        minX -= mainCamera.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
        maxX -= mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ResumeButtonClicked()
    {
        Time.timeScale = 1;
        GameSystem.GetGameSystem().SetGamePaused(false);
        pauseMenu.SetActive(false);
        pauseOverlay.SetActive(false);
    }

    public void TipsButtonClicked()
    {
        tipsDialog.SetActive(true);
    }

    public void TipsOkButtonClicked()
    {

    }

    public void QuitButtonClicked()
    {
        DialogUI dialog = GameSystem.GetGameSystem().GetControlUI().dialogUI;
        dialog.gameObject.SetActive(true);
        dialog.SetMessage("Quit game?");
        dialog.SetDialogType(true);
        dialog.SetInterface(this);

        pauseMenu.SetActive(false);
        pauseOverlay.SetActive(false);
    }

    public void PauseButtonClicked()
    {
        if (GameSystem.GetGameSystem().IsGameStarted())
            if (GameSystem.GetGameSystem().IsGamePaused())
            {
                Time.timeScale = 1;
                GameSystem.GetGameSystem().SetGamePaused(false);
                pauseMenu.SetActive(false);
                pauseOverlay.SetActive(false);
            }
            else
            {
                Time.timeScale = 0;
                GameSystem.GetGameSystem().SetGamePaused(true);
                pauseMenu.SetActive(true);
                pauseOverlay.SetActive(true);
            }
    }

    public void GameOverLay()
    {
        pauseOverlay.SetActive(true);
        pauseButton.SetActive(false);
        returnButton.SetActive(true);
        GameSystem.GetGameSystem().ShowIntersitialAds();
    }

    public void OnReturnButtonClick()
    {
        GameSystem.GetGameSystem().MoveToMainMenu();
    }

    public TowerInternalUI GetTowerInternalUI()
    {
        return towerInternalUI;
    }

    public void RemoveDialogUI()
    {
        dialogUI.gameObject.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.pointerPressRaycast.gameObject.tag == "GameController" && !isDragging)
        {
            RaycastHit2D hitRay = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(eventData.position), Vector2.zero);
            if (hitRay)
            {
                if (hitRay.collider.gameObject.tag == "AddTower")
                {
                    AddNewFloor();
                }
                else if (hitRay.collider.gameObject.tag == "Tower")
                {
                    LoadTowerFloorToUI(hitRay.collider.gameObject);
                }
            }
        }
        else
        {

        }
    }

    public void GameOver()
    {
        canMove = false;
        mainCamera.transform.position = new Vector3(0, minY, -10);
        towerInternalUI.ClearSelection();
        towerInternalUI.ClearTowerFloor();
        RemoveDialogUI();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (canMove)
        {
            moveDirection = -eventData.delta;
            if (((moveDirection.x * 0.01f) + mainCamera.transform.position.x < minX) || ((moveDirection.x * 0.01f) + mainCamera.transform.position.x > maxX))
            {
                moveDirection = new Vector2(0, moveDirection.y);
            }
            if ((moveDirection.y * 0.01f) + mainCamera.transform.position.y < minY || (moveDirection.y * 0.01f) + mainCamera.transform.position.y > maxY)
            {
                moveDirection = new Vector2(moveDirection.x, 0);
            }
            if (eventData.pointerPressRaycast.gameObject.tag == "GameController")
            {
                mainCamera.transform.Translate(moveDirection * 0.01f);
            }
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
        if (canMove)
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
        pauseButton.SetActive(true);
    }

    public void OnOkButtonClicked()
    {
    }

    public void OnNoButtonClicked()
    {
        pauseMenu.SetActive(true);
        pauseOverlay.SetActive(true);
    }

    public void OnYesButtonClicked()
    {
        SceneManager.LoadScene(0);
    }

    public void OnStartButtonClicked()
    {
        GameSystem.GetGameSystem().SpawnEnemyStart();
        startButton1.SetActive(false);
        startButton2.SetActive(false);
    }
}
