using UnityEngine;
using System.Collections;

public class TowerInternalUI : MonoBehaviour {

    public ArtilleryUI leftAUI;
    public SupportUI leftSUI;
    public ArtilleryUI rightAUI;
    public SupportUI rightSUI;
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
        leftAUI.SetName(leftArtillery.getName());
        leftSUI.SetName(leftArtillery.GetSupport().getName());
        rightAUI.SetName(rightArtillery.getName());
        rightSUI.SetName(rightArtillery.GetSupport().getName());
    }

    public void ClearSelection()
    {
        leftAUI.SetUnselected();
        leftSUI.SetUnselected();
        rightAUI.SetUnselected();
        rightSUI.SetUnselected();
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

    public void SetLeftSupportToUpgrade()
    {
        towerUpgradeUI.SetSupportToUpgrade(towerFloorScript.GetLeftArtillery());
    }

    public void SetRightSupportToUpgrade()
    {
        towerUpgradeUI.SetSupportToUpgrade(towerFloorScript.GetRightArtillery());
    }
}
