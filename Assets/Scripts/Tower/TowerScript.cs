using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class TowerScript : MonoBehaviour, DialogInterface
{

    public GameObject towerBodyPrefab;
    public GameObject towerAddButton;
    int cost = 1;

    // Use this for initialization
    void Start()
    {
        //InvokeRepeating("Sink", 3, 3);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Sink()
    {
        transform.position = new Vector3(0, transform.position.y - 1.68f);
        if (transform.childCount > 2) // <2 game over, >2 sink
        {
            Destroy(transform.GetChild(1).gameObject);
        }
        CancelInvoke();
    }

    public void AddFloorDialog()
    {
        DialogUI dialog = GameSystem.GetGameSystem().GetControlUI().dialogUI;
        dialog.gameObject.SetActive(true);
        dialog.SetMessage("Add new floor for " + GetCurrentCost() + " gold?");
        dialog.SetDialogType(true);
        dialog.SetInterface(this);
    }

    public void OnOkButtonClicked()
    {
    }

    public void OnNoButtonClicked()
    {
    }

    public void OnYesButtonClicked()
    {
        if (GameSystem.GetGameSystem().GetGold() >= GetCurrentCost())
        {
            GameSystem.GetGameSystem().AddGold(-GetCurrentCost());
            cost++;
            AddFloor();
        }
    }

    private int GetCurrentCost()
    {
        switch (cost)
        {
            case 1:
                return 100;
            case 2:
                return 2000;
            case 3:
                return 5000;
            default:
                return 100;
        }
    }

    public void DestroyFloor(int index)
    {
        for (int i = index; i < transform.childCount; i++)
        {
            if (i != index)
            {
                transform.GetChild(i).transform.position = transform.GetChild(i).transform.position - new Vector3(0, 1.06f);
            }
        }
        towerAddButton.transform.position = new Vector2(0, 1.06f * (transform.childCount - 3) + 0.865f);
        Destroy(transform.GetChild(index).gameObject);
        ControlUI.GetUI().GetTowerInternalUI().ClearSelection();
    }

    private void AddFloor()
    {
        GameObject newFloor = (GameObject)Instantiate(towerBodyPrefab, transform);
        newFloor.transform.position = new Vector2(0, 1.06f * (transform.childCount - 2));
        towerAddButton.transform.position = new Vector2(0, 1.06f * (transform.childCount - 2) + 0.865f);
        GameSystem.GetGameSystem().GetSpawnSystem().UpdateSpawnerList();
    }
}
