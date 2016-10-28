using UnityEngine;
using System.Collections;

public class SupportScript : MonoBehaviour {

    private string supportName;
    private SupportInterface implements;
    public ArtilleryScript left;
    public ArtilleryScript right;

	// Use this for initialization
	void Start () {
        supportName = "No support installed";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetImplements(SupportModel model)
    {
        left.RemoveSupportedEffect();
        right.RemoveSupportedEffect();
        supportName = model.name;
        implements = model.supportImpl;
        GetComponentInParent<TowerFloorScript>().LoadTowerFloorToUI();
        left.ApplySupportedEffect();
        right.ApplySupportedEffect();
    }

    public string getName()
    {
        return supportName;
    }

    public SupportInterface GetImplements()
    {
        return implements;
    }
}
