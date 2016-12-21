using UnityEngine;
using System.Collections;

public class TowerInternalUI : MonoBehaviour {

    public ArtilleryUI leftAUI;
    public SupportUI supportUI;
    public ArtilleryUI rightAUI;
    public TowerUpgradeUI towerUpgradeUI;

    private TowerFloorScript towerFloorScript;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoadTowerFloor(ArtilleryScript leftArtillery, ArtilleryScript rightArtillery)
    {
        leftAUI.SetModel(leftArtillery.GetModel());
        supportUI.SetName(leftArtillery.GetSupport().model);
        rightAUI.SetModel(rightArtillery.GetModel());
    }

    public void ClearSelection()
    {
        leftAUI.SetUnselected();
        supportUI.SetUnselected();
        rightAUI.SetUnselected();
        towerUpgradeUI.ClearList();
    }

    public void SetTowerFloorScript(TowerFloorScript script)
    {
        towerFloorScript = script;
    }

    public void SetLeftArtilleryToUpgrade()
    {
        towerUpgradeUI.SetArtilleryToUpgrade(towerFloorScript.GetLeftArtillery());
    }

    public void SetRightArtilleryToUpgrade()
    {
        towerUpgradeUI.SetArtilleryToUpgrade(towerFloorScript.GetRightArtillery());
    }

    public void SetSupportToUpgrade()
    {
        towerUpgradeUI.SetSupportToUpgrade(towerFloorScript.GetSupport());
    }

}
