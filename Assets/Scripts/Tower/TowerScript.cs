using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class TowerScript : MonoBehaviour, DialogInterface
{

    public GameObject towerBodyPrefab;
    public GameObject towerAddButton;

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
        dialog.SetMessage("Add new floor for 100 gold?");
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
        if (GameSystem.GetGameSystem().GetGold() > 100)
        {
            GameSystem.GetGameSystem().AddGold(-100);
            AddFloor();
        }
    }

    private void AddFloor()
    {
        GameObject newFloor = (GameObject)Instantiate(towerBodyPrefab, transform);
        newFloor.transform.position = new Vector2(0, 1.68f * (transform.childCount - 2));
        towerAddButton.transform.position = new Vector2(0, 1.68f * (transform.childCount - 2) + 1.23f);
    }
}
