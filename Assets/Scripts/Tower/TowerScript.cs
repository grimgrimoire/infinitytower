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

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddFloorDialog()
    {
        DialogUI dialog = GameSystem.GetGameSystem().GetControlUI().dialogUI;
        dialog.gameObject.SetActive(true);
        dialog.SetMessage("Add new floor for " + GetCurrentCost() + " gold?");
        dialog.SetDialogType(true);
        dialog.SetInterface(this);
    }

    public void ClearTowerSelection()
    {
        TowerFloorScript[] scripts = GetComponentsInChildren<TowerFloorScript>();
        foreach(TowerFloorScript script in scripts)
        {
            script.ClearSelection();
        }
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
            GameSystem.GetGameSystem().TakeDamage(-5);
            cost++;
            AddFloor();
        }
        else
            NotEnoughtGold();
    }

    public void NotEnoughtGold()
    {
        DialogUI dialog = GameSystem.GetGameSystem().GetControlUI().dialogUI;
        dialog.gameObject.SetActive(true);
        dialog.SetDialogType(false);
        dialog.SetMessage("Not enough gold");
    }

    public void GameOverAnimation()
    {
        StartCoroutine(GameOverAnimationIE());
        foreach (TowerFloorScript tfs in GetComponentsInChildren<TowerFloorScript>())
        {
            tfs.RemoveAllArtillery();
        }
    }

    IEnumerator GameOverAnimationIE()
    {
        GameObject cloudAnimation = Resources.Load("Prefab/Ruin", typeof(GameObject)) as GameObject;
        GameObject cAInstance = GameObject.Instantiate(cloudAnimation);
        float heightModifier = (transform.childCount - 1) * 1.06f;
        while (heightModifier > 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, (Vector2)transform.position + Vector2.down, Time.deltaTime);
            heightModifier -= Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        GameObject.Destroy(cAInstance);
        GameObject rubble = Resources.Load("Prefab/Rubble", typeof(GameObject)) as GameObject;
        Instantiate(rubble);
        GameSystem.GetGameSystem().GetControlUI().GameOverLay();
        GameSystem.GetGameSystem().GetInfoUI().SetFinalScore();
    }

    private int GetCurrentCost()
    {
        switch (cost)
        {
            case 1:
                return 100;
            case 2:
                return 800;
            case 3:
                return 1200;
            case 4:
                return 1500;
            default:
                return 2000;
        }
    }

    private void AddFloor()
    {
        GameObject newFloor = (GameObject)Instantiate(towerBodyPrefab, transform);
        newFloor.transform.position = new Vector2(0, 1.06f * (transform.childCount - 2));
        towerAddButton.transform.position = new Vector2(0, 1.06f * (transform.childCount - 2) + 0.865f);
        GameSystem.GetGameSystem().GetSpawnSystem().UpdateSpawnerList();
    }
}
