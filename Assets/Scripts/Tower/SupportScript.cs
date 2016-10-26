using UnityEngine;
using System.Collections;

public class SupportScript : MonoBehaviour {

    private string supportName;
    private SupportInterface implements;

	// Use this for initialization
	void Start () {
        supportName = "No support installed";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetImplements(SupportModel model)
    {
        supportName = model.name;
        implements = model.supportImpl;
        GetComponentInParent<TowerFloorScript>().LoadTowerFloorToUI();
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
