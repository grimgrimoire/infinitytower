using UnityEngine;
using System.Collections;

public class TowerFloorScript : MonoBehaviour {

    ArtilleryScript leftArtillery;
    ArtilleryScript rightArtillery;
    SupportScript leftSupport;
    SupportScript rightSupport;

	// Use this for initialization
	void Start () {
        leftArtillery = new ArtilleryScript();
        rightArtillery = new ArtilleryScript();
        leftSupport = new SupportScript();
        rightSupport = new SupportScript();
        leftArtillery.setSupport(leftSupport);
        rightArtillery.setSupport(rightSupport);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoadTowerFloorToUI()
    {
        ControlUI.GetUI().GetTowerInternalUI().LoadTowerFloor(leftArtillery, leftSupport, rightArtillery, rightSupport);
    }
}
