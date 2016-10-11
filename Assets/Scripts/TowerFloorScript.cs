using UnityEngine;
using System.Collections;

public class TowerFloorScript : MonoBehaviour {

    ArtilleryScript leftArtillery;
    ArtilleryScript rightArtillery;
    SupportScript leftSupport;
    SupportScript rightSupport;

	// Use this for initialization
	void Start () {
        leftArtillery = transform.GetChild(0).GetComponent<ArtilleryScript>();
        rightArtillery = transform.GetChild(1).GetComponent<ArtilleryScript>();
        leftSupport = gameObject.AddComponent<SupportScript>();
        rightSupport = gameObject.AddComponent<SupportScript>();
        leftArtillery.setSupport(leftSupport);
        rightArtillery.setSupport(rightSupport);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public ArtilleryScript GetLeftArtillery()
    {
        return leftArtillery;
    }

    public ArtilleryScript GetRightArtillery()
    {
        return rightArtillery;
    }

    public void LoadTowerFloorToUI()
    {
        ControlUI.GetUI().GetTowerInternalUI().LoadTowerFloor(leftArtillery, leftSupport, rightArtillery, rightSupport);
        ControlUI.GetUI().GetTowerInternalUI().SetTowerFloorScript(this);
    }
}
