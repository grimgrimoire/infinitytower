using UnityEngine;
using System.Collections;

public class ArtilleryScript : MonoBehaviour {

    private string artilleryName;
    SupportScript supportScript;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setSupport(SupportScript supportScript)
    {
        this.supportScript = supportScript;
    }
}
